using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;
namespace Dal;

internal class ProductImplementation : IProduct
{
    readonly string s_path = @"..\xml\products.xml";
    public int Add(Product product)
    {
        List<Product> products = XMLTools.LoadListFromXMLSerializer<Product>(s_path);
        int nextId = Config.getProductNum;
        Product newItem=product with { Id=nextId }; 
        products.Add(newItem);
        XMLTools.SaveListToXMLSerializer(products, s_path); 
        return nextId;

    }

    public int Create(Product item)
    {
       return Add(item);
    }

    public void Delete(int id)
    {
        List<Product> products = XMLTools.LoadListFromXMLSerializer<Product>(s_path);
        var ptoremove = products.FirstOrDefault(p => p.Id == id);
        if(ptoremove == null) 
            throw new Exception($"Product with ID {id} does not exist");
        products.Remove(ptoremove);
        XMLTools.SaveListToXMLSerializer<Product>(products, s_path);

    }

    public Product?Read(int id)
    {
        List<Product>products=XMLTools.LoadListFromXMLSerializer<Product>(s_path); 
        return products.FirstOrDefault(p=>p.Id==id);
    }

    public Product? Read(Func<Product, bool> filter)
    {
        List<Product> products = XMLTools.LoadListFromXMLSerializer<Product>(s_path);
        return products.FirstOrDefault(filter);
    }

    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        List<Product> products = XMLTools.LoadListFromXMLSerializer<Product>(s_path);
        if (filter == null)
        {
            return products.Cast<Product?>().ToList();
        }
        return products.Where(filter).Cast<Product?>().ToList();    
    }

    public void Update(Product item)
    {
        List<Product> products = XMLTools.LoadListFromXMLSerializer<Product>(s_path);
        int i=products.FindIndex(p=>p.Id==item.Id);
        if(i==-1)
            throw new Exception($"Product with ID {item.Id} not found");
        products[i]= item;
        XMLTools.SaveListToXMLSerializer(products,s_path);
    }
}
