using BL.BO;
using System.Collections.Generic;

namespace BL.BlApi;

public interface IOrder
{
    List<SaleInProduct> AddProductToOrder(Order order, int productId, int quantity);
    void CalcTotalPriceForProduct(ProductInOrder pInOrder);
    void CalcTotalPrice(Order order);
    void DoOrder(Order order);
    void SearchSaleForProduct(ProductInOrder pInOrder, bool isPreferred);
}