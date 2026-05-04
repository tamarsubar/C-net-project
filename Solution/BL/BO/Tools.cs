using System.Reflection;
using System.Collections;
using System.Text;
using BL.BO;

namespace BL.BO;

public static class Tools
{
    public static string ToStringProperty<T>(this T t)
    {
        if (t == null) return "";
        StringBuilder sb = new StringBuilder();
        Type type = t.GetType();
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            var value = property.GetValue(t, null);
            if (value is IEnumerable enumerable && !(value is string))
            {
                sb.Append($"\n {property.Name}: ");
                foreach (var item in enumerable) sb.Append($"{item}, ");
            }
            else
            {
                sb.Append($"\n {property.Name}: {value}");
            }
        }
        return sb.ToString();
    }

    public static DO.Customer ToDO(this Customer bo) => new() { Id = bo.Id, Name = bo.Name, Address = bo.Address, Phone = bo.Phone };
    public static Customer ToBO(this DO.Customer doCustomer) => new() { Id = doCustomer.Id, Name = doCustomer.Name, Address = doCustomer.Address, Phone = doCustomer.Phone };

    public static DO.Product ToDO(this Product bo) => new() { Id = bo.Id, Name = bo.Name, Price = bo.Price, QuantityInStock = bo.QuantityInStock, Category = (DO.category)bo.Category };
    public static Product ToBO(this DO.Product doProduct) => new() { Id = doProduct.Id, Name = doProduct.Name, Price = doProduct.Price, QuantityInStock = doProduct.QuantityInStock, Category = (Enum)doProduct.Category };

    public static DO.Sale ToDO(this Sale bo) => new()
    {
        Id = bo.Id,
        IdProduct = bo.IdProduct,
        CountForSale = bo.CountForSale,
        TotalPrice = bo.TotalPrice,
        NeedClub = bo.NeedClub,
        StartSale = bo.StartSale,
        FinishSale = bo.FinishSale
    };

    public static Sale ToBO(this DO.Sale doSale) => new()
    {
        Id = doSale.Id,
        IdProduct = doSale.IdProduct,
        CountForSale = doSale.CountForSale,
        TotalPrice = doSale.TotalPrice,
        NeedClub = doSale.NeedClub,
        StartSale = doSale.StartSale,
        FinishSale = doSale.FinishSale
    };

    public static BO.SaleInProduct ToSaleInProduct(this DO.Sale doSale) => new()
    {
        Id = doSale.Id,
        CountForSale = doSale.CountForSale,
        Price = doSale.TotalPrice,
        NeedClub = doSale.NeedClub
    };
}