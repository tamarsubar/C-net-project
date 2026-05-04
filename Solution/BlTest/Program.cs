using BL.BO;
using BL.BlApi; 

namespace BlTest;

class Program
{
    private static readonly BL.BlApi.IBl s_bl = BL.BlApi.Factory.Get;
    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("\n--- Main Menu: Select Entity ---");
            Console.WriteLine("1 - Customers | 2 - Products | 3 - Promotions | 0 - Exit");
            choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1: CustomerMenu(); break;
                case 2: ProductMenu(); break;
                case 3: SaleMenu(); break;
                case 0: Console.WriteLine("finish..."); break;
                default: Console.WriteLine("Incorrect choice"); break;
            }
        } while (choice != 0);
    }

    private static void CustomerMenu()
    {
        try
        {
            Console.WriteLine("Selection: 1-Add | 2-View | 3-Update | 4-Delete | 5-Show all");
            int sub = int.Parse(Console.ReadLine()!);
            switch (sub)
            {
                case 1:
                    Console.Write("Enter ID, Name, Address, Phone: ");
                    s_bl.Customer.Create(new Customer { Id = int.Parse(Console.ReadLine()!), Name = Console.ReadLine()!, Address = Console.ReadLine()!, Phone = Console.ReadLine()! });
                    break;
                case 2:
                    Console.Write("Enter ID: ");
                    Console.WriteLine(s_bl.Customer.Read(int.Parse(Console.ReadLine()!)));
                    break;
                case 3:
                    Console.Write("Enter ID to update: ");
                    int idToUpdate = int.Parse(Console.ReadLine()!);

                    var existing = s_bl.Customer.Read(idToUpdate);
                    Console.WriteLine($"Current data: {existing}");

                    Console.Write("Enter New Name, Address, Phone: ");
                    s_bl.Customer.Update(new Customer
                    {
                        Id = idToUpdate,
                        Name = Console.ReadLine()!,
                        Address = Console.ReadLine()!,
                        Phone = Console.ReadLine()!
                    });
                    Console.WriteLine("Updated successfully.");
                    break;
                case 4:
                    Console.Write("Enter ID to delete: ");
                    int idToDelete = int.Parse(Console.ReadLine()!);
                    s_bl.Customer.Delete(idToDelete);
                    Console.WriteLine("Deleted successfully.");
                    break;
                case 5:
                    s_bl.Customer.ReadAll().ToList().ForEach(c => Console.WriteLine(c));
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroor: {ex.Message}");
        }
    }
    private static void ProductMenu()
    {
        try
        {
            Console.WriteLine("1-Add | 2-View | 5-Show All");
            int sub = int.Parse(Console.ReadLine()!);
            switch (sub)
            {
                case 1:
                    Console.Write("Enter ID, Name, Category (0-2), Price, Quantity: ");
                    s_bl.Product.Create(new Product { Id = int.Parse(Console.ReadLine()!), Name = Console.ReadLine()!, Category = (Category)int.Parse(Console.ReadLine()!), Price = double.Parse(Console.ReadLine()!), QuantityInStock = int.Parse(Console.ReadLine()!) });
                    break;
                case 2:
                    Console.Write("Enter ID: ");
                    Console.WriteLine(s_bl.Product.Read(int.Parse(Console.ReadLine()!)));
                    break;
                case 5:
                    s_bl.Product.ReadAll().ToList().ForEach(p => Console.WriteLine(p));
                    break;
            }
        }
        catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
    }

    private static void SaleMenu()
    {
        try
        {
            Console.WriteLine("1-Add | 2-View |3-Show All");
            int sub = int.Parse(Console.ReadLine()!);
            switch (sub)
            {
                case 1:
                    Console.Write("Enter ID, Product ID, Count for Sale, Total Price: ");
                    s_bl.Sale.Create(new Sale
                    {
                        Id = int.Parse(Console.ReadLine()!),
                        IdProduct = int.Parse(Console.ReadLine()!),
                        CountForSale = int.Parse(Console.ReadLine()!), 
                        TotalPrice = double.Parse(Console.ReadLine()!)
                    }); break;
                case 2:
                    Console.Write("Enter ID: ");
                    Console.WriteLine(s_bl.Sale.Read(int.Parse(Console.ReadLine()!)));
                    break;
                case 3:
                    s_bl.Sale.ReadAll().ToList().ForEach(s => Console.WriteLine(s));
                    break;
            }
        }
        catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
    }
}