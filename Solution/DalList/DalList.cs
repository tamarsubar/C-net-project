using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal sealed class DalList:IDal
    {
        private static readonly DalList instance = new DalList();
        public static DalList Instance => instance;

        private DalList() { }
        public ICustomer Customer=> new CustomerImplementation();
        public ISale Sale => new SaleImplementation();
        public IProduct Product => new ProductImplementation();
    }
}
