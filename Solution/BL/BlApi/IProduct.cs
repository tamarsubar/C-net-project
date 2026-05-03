using BL.BO;

namespace BL.BlApi;

public interface IProduct
{
    int Create(Product product);
    Product? Read(int id);
    IEnumerable<Product> ReadAll(Func<Product, bool>? filter = null);
    void Update(Product product);
    void Delete(int id);

}