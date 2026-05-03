using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DO;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    readonly string s_path = @"..\xml\customers.xml";
    public int Add(Customer customer)
    {
        XElement root = XElement.Load(s_path);
        root.Add(new XElement("Customer",
            new XElement("Id", customer.Id),
            new XElement("Name", customer.Name),
            new XElement("Address", customer.Address),
            new XElement("Phone", customer.Phone)
            ));
        root.Save(s_path);
        return customer.Id;


    }
    public int Create(Customer item)
    {
        return Add(item);
    }

    public void Delete(int id)
    {
        XElement root= XElement.Load(s_path);
        XElement? customer=(from c in root.Elements("Customer")
                            where (int)c.Element("Id")! == id
                            select c).FirstOrDefault();
        if (customer != null)
        {
            customer.Remove();
            root.Save(s_path);
        }
    }

    public Customer? Read(int id)
    {
        XElement root = XElement.Load(s_path);
        return (from c in root.Elements("Customer")
                where (int?)c.Element("Id")! == id
                select new Customer
                {
                    Id = (int)c.Element("Id")!,
                    Name= (string)c.Element("Name")!,
                    Address=(string)c.Element("Address")!,
                    Phone=(string)c.Element("Phone")!

                }).FirstOrDefault();
       
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        return ReadAll().FirstOrDefault(filter!);
    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        XElement root=XElement.Load(s_path);
        var customers = (from c in root.Elements("Customer")
                         select new Customer
                         {
                             Id = (int)c.Element("Id")!,
                             Name = (string)c.Element("Name")!,
                             Address = (string)c.Element("Address")!,
                             Phone = (string)c.Element("Phone")!
                         }).Cast<Customer?>();
        if(filter == null)
            return customers.ToList();
        return customers.Where(filter!).ToList();
    }

    public void Update(Customer item)
    {
       Delete(item.Id);
       Add(item);
    }
}
