using DO;
using DalApi;


namespace DalTest;

public class Initialization
{
    private static IDal s_dal;
   


    private static void CreateCustomer()
    {
        s_dal.Customer.Create(new Customer(123, "Elisheva", "rashbi", "0583292053"));
        s_dal.Customer.Create(new Customer(13, "tamar", "rabbi", "0564532156"));
        s_dal.Customer.Create(new Customer(1223, "esty", "netivotHamishpat", "0556453215"));
        s_dal.Customer.Create(new Customer(1243, "rivki", "rashbi", "0458546987"));

    }
    private static void CreateSale()
    {
        s_dal.Sale.Create(new Sale(0, 01, 40, 120.0, true, DateTime.Today, new DateTime(1, 1, 2026)));
        s_dal.Sale.Create(new Sale(0, 02, 30,159.9, true, DateTime.Today, new DateTime(1, 1, 2026)));
        s_dal.Sale.Create(new Sale(0, 03, 50, 300.0, true, DateTime.Today, new DateTime(1, 1, 2026)));
        s_dal.Sale.Create(new Sale(0, 04, 60,299.99, true, DateTime.Today, new DateTime(1, 1, 2026)));
    }
    private static void CreateProduct()
    {
        s_dal.Product.Create(new Product(01, "Luxury European Style Wall Clock", category.birthDay, 200, 22));
        s_dal.Product.Create(new Product(03, "Challah Cover - The Perfect Holiday Gift", category.holiday, 369.9, 12));
        s_dal.Product.Create(new Product(04, "Picture Frames - The Perfect Gift", category.holiday, 100, 59));
    }
    
    public static void Initialize()
    {
        s_dal = DalApi.Factory.Get;
        CreateCustomer();
        CreateProduct ();
        CreateSale();
    }
}
