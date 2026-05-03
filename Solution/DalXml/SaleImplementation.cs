using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;

namespace Dal;

internal class SaleImplementation : ISale
{
    readonly string s_path = @"..\xml\Sales.xml";
    public int Add(Sale Sale)
    {
        List<Sale> Sales = XMLTools.LoadListFromXMLSerializer<Sale>(s_path);
        int nextId = Config.getSaleNum;
        Sale newItem = Sale with { Id = nextId };
        Sales.Add(newItem);
        XMLTools.SaveListToXMLSerializer(Sales, s_path);
        return nextId;

    }

    public int Create(Sale item)
    {
        return Add(item);
    }

    public void Delete(int id)
    {
        List<Sale> Sales = XMLTools.LoadListFromXMLSerializer<Sale>(s_path);
        var ptoremove = Sales.FirstOrDefault(p => p.Id == id);
        if (ptoremove == null)
            throw new Exception($"Sale with ID {id} does not exist");
        Sales.Remove(ptoremove);
        XMLTools.SaveListToXMLSerializer<Sale>(Sales, s_path);

    }

    public Sale? Read(int id)
    {
        List<Sale> Sales = XMLTools.LoadListFromXMLSerializer<Sale>(s_path);
        return Sales.FirstOrDefault(p => p.Id == id);
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        List<Sale> Sales = XMLTools.LoadListFromXMLSerializer<Sale>(s_path);
        return Sales.FirstOrDefault(filter);
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        List<Sale> Sales = XMLTools.LoadListFromXMLSerializer<Sale>(s_path);
        if (filter == null)
        {
            return Sales.Cast<Sale?>().ToList();
        }
        return Sales.Where(filter).Cast<Sale?>().ToList();
    }

    public void Update(Sale item)
    {
        List<Sale> Sales = XMLTools.LoadListFromXMLSerializer<Sale>(s_path);
        int i = Sales.FindIndex(p => p.Id == item.Id);
        if (i == -1)
            throw new Exception($"Sale with ID {item.Id} not found");
        Sales[i] = item;
        XMLTools.SaveListToXMLSerializer(Sales, s_path);
    }
}
