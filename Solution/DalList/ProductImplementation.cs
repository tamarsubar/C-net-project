

using DalApi;
using DO;
using static Dal.DalExceptions;

namespace Dal;

internal class ProductImplementation : IProduct
{
    public int Create(Product p)
    {
        Product product = p with { Id = DataSource.Config.ProductCode };

        DataSource.Products.Add(product);
        return product.Id;
    }

    public Product Read(int id)
    {
        var exist = DataSource.Products.FirstOrDefault(p => p.Id == id);

        if (exist == null)
            throw new DalExceptionNotExist("The product does not exist in the system.");
        return exist;
    }
    public Product Read(Func<Product, bool> filter)
    {
        return DataSource.Products.FirstOrDefault(filter);
    } 

    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        if(filter == null)
            return DataSource.Products.ToList();
        return DataSource.Products.Where(filter).ToList();
    }

    public void Delete(int id)
    {

        var exist = DataSource.Products.FirstOrDefault(p => p.Id == id);

        if (exist == null)
            throw new DalExceptionNotExist("The product does not exist in the system.");

        DataSource.Products.Remove(exist);
    }

    public void Update(Product s)
    {

        var exist = DataSource.Products.FirstOrDefault(p => p.Id == s.Id);

        if (exist == null)
            throw new DalExceptionNotExist("The product does not exist in the system.");
        DataSource.Products.Remove(exist);
        DataSource.Products.Add(s);
    }

}
