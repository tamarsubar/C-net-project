using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DO
{
    public record Sale(int Id, int IdProduct, int CountForSale, double TotalPrice, bool NeedClub, DateTime StartSale, DateTime FinishSale)
    {
       
        public Sale() : this(0, 123, 50, 100.0, true, DateTime.Now, DateTime.Now) { }
        public override string ToString() =>
                    $"Customer ID: {Id},\n IdProduct: {IdProduct},\n CountForSale: {CountForSale},\n TotalPrice: {TotalPrice},\n NeedClub: {NeedClub},\n StartSale: {StartSale},\n FinishSale: {FinishSale}";
    }
}
