using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dal
{
    internal static class Config
    {
        private static string s_data_config_xml = "data-config";

        private static string s_path = @"..\..\..\..\xml\data-config.xml"; 
        public static int getProductNum
        {
            get => GetAndIncrement("ProductNum");
        }

        public static int getSaleNum
        {
            get => GetAndIncrement("SaleNum");
        }
        public static int GetAndIncrement(string element)
        {
            XElement root = XElement.Load(s_path);
            int currentVal=(int)root.Element(element); ;
            root.Element(element)!.SetValue(currentVal+1);
            root.Save(s_path);
            return currentVal;
        }
       
    }
}
