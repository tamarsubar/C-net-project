using BL.BlApi;
using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.BlImplementation;

internal class OrderImplementation : IOrder
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;

    public List<SaleInProduct> AddProductToOrder(Order order, int productId, int quantity)
    {
        // 1. שליפת המוצר מה-DAL לבדיקת מלאי
        var dalProduct = _dal.Product.Read(productId)
            ?? throw new Exception("Product not found");

        if (dalProduct.QuantityInStock < quantity)
            throw new Exception("Not enough in stock");

        order.Items ??= new List<ProductInOrder>();
        var item = order.Items.FirstOrDefault(i => i.ProductId == productId);

        // 2. עדכון הפריט ברשימה של ה-BO
        if (item != null)
        {
            item.QuantityInOrder += quantity;
        }
        else
        {
            item = new ProductInOrder
            {
                ProductId = productId,
                ProductName = dalProduct.Name,
                BasePrice = dalProduct.Price,
                QuantityInOrder = quantity
            };
            order.Items.Add(item);
        }

        // 3. עדכון מלאי מיידי ב-DAL (כפי שביקשת)
        _dal.Product.Update(dalProduct with { QuantityInStock = dalProduct.QuantityInStock - quantity });

        // 4. חישוב מחירים ומבצעים מחדש
        SearchSaleForProduct(item, order.IsPreferredCustomer);
        CalcTotalPriceForProduct(item);
        CalcTotalPrice(order);

        return item.Sales ?? new List<SaleInProduct>();
    }

    public void SearchSaleForProduct(ProductInOrder pInOrder, bool isPreferred)
    {
        // שליפת המבצעים וסינון לפי כמות וסוג לקוח
        pInOrder.Sales = _dal.Sale.ReadAll(s => s.IdProduct == pInOrder.ProductId)
            .Where(s => pInOrder.QuantityInOrder >= s.CountForSale)
            .Where(s => isPreferred || !s.NeedClub)
            .Select(s => s.ToSaleInProduct()) // המרה בעזרת Tools.cs
            .OrderBy(s => s.TotalPrice / s.CountForSale) // מיון לפי המחיר המשתלם ביותר ליחידה
            .ToList();
    }

    public void CalcTotalPriceForProduct(ProductInOrder pInOrder)
    {
        double finalPrice = 0;
        int remaining = pInOrder.QuantityInOrder;
        List<SaleInProduct> applied = new();

        // מימוש המבצעים מהזול ליקר
        foreach (var sale in pInOrder.Sales ?? new())
        {
            if (remaining < sale.CountForSale) continue;

            int times = remaining / sale.CountForSale;
            finalPrice += times * sale.TotalPrice;
            remaining %= sale.CountForSale;
            applied.Add(sale);

            if (remaining == 0) break;
        }

        // הוספת השארית לפי מחיר בסיס
        finalPrice += remaining * pInOrder.BasePrice;

        pInOrder.Sales = applied; // שמירת המבצעים שמומשו בפועל
        pInOrder.TotalPrice = finalPrice;
    }

    public void CalcTotalPrice(Order order)
    {
        order.TotalPrice = order.Items?.Sum(i => i.TotalPrice) ?? 0;
    }

    public void DoOrder(Order order)
    {
        // המלאי כבר עודכן ב-AddProductToOrder. 
        // כאן ניתן להוסיף לוגיקה של סיום (כמו הדפסת סיכום או ניקוי העגלה)
        Console.WriteLine($"Order completed! Final price: {order.TotalPrice}");
    }
}