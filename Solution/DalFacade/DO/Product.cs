using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Product(int Id,string Name,Enum Category,double Price,int QuantityInStock)
    {
        public Product() : this(0, "", category.birthDay, 1.1, 5) { }
        public override string ToString() =>
            $"Customer ID: {Id},\n Name: {Name},\n Category: {Category},\n Price: {Price},\n QuantityInStock: {QuantityInStock}";
    }
}
