using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace Dal;

public sealed class DalXml : IDal
{
    public ICustomer Customer => new CustomerImplementation();
    public ISale Sale => new SaleImplementation();
    public IProduct Product => new ProductImplementation();

    private DalXml()
    {
        
    }
    private static readonly DalXml instance= new DalXml();  
    public static DalXml Instance=>instance;

}
