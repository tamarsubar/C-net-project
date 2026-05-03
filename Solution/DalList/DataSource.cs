

using DO;

namespace Dal;

internal static class DataSource
{
    internal static List<Customer> customers = new();
    internal static List<Sale> Sales = new();
    internal static List<Product> Products = new();

    internal static class Config
    {
        internal const int ProductCode = 100;
        internal const int SaletMinCode = 200;

        private static int ProductIndex = ProductCode;
        private static int SaleIndex = SaletMinCode;

        //public static int ProductCode => ProductIndex++;
        public static int SaleCode => SaleIndex++;

        






    }
}
