using BlApi;
using BO;

namespace BlTest;

class Program
{
    private static readonly IBl s_bl = Factory.Get();

    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("\n--- תפריט ראשי: בחר ישות ---");
            Console.WriteLine("1 - לקוחות | 2 - מוצרים | 3 - מבצעים | 0 - יציאה");
            choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1: CustomerMenu(); break;
                case 2: ProductMenu(); break;
                case 3: SaleMenu(); break;
                case 0: Console.WriteLine("סיום..."); break;
                default: Console.WriteLine("בחירה לא תקינה"); break;
            }
        } while (choice != 0);
    }

    private static void CustomerMenu()
    {
        try
        {
            Console.WriteLine("1-הוספה | 2-צפייה | 3-עדכון | 4-מחיקה | 5-הצג הכל");
            int sub = int.Parse(Console.ReadLine()!);
            switch (sub)
            {
                case 1:
                    Console.Write("הזן ID, שם, כתובת, טלפון: ");
                    s_bl.Customer.Create(new Customer { Id = int.Parse(Console.ReadLine()!), Name = Console.ReadLine()!, Address = Console.ReadLine()!, Phone = Console.ReadLine()! });
                    break;
                case 2:
                    Console.Write("הזן ID: ");
                    Console.WriteLine(s_bl.Customer.Read(int.Parse(Console.ReadLine()!)));
                    break;
                case 5:
                    s_bl.Customer.ReadAll().ToList().ForEach(c => Console.WriteLine(c));
                    break;
                    // להוסיף עדכון ומחיקה באותו סגנון...
            }
        }
        catch (Exception ex) { Console.WriteLine($"שגיאה: {ex.Message}"); }
    }

    private static void ProductMenu()
    {
        try
        {
            Console.WriteLine("1-הוספה | 2-צפייה | 5-הצג הכל");
            int sub = int.Parse(Console.ReadLine()!);
            switch (sub)
            {
                case 1:
                    Console.Write("הזן ID, שם, קטגוריה (0-2), מחיר, כמות: ");
                    s_bl.Product.Create(new Product { Id = int.Parse(Console.ReadLine()!), Name = Console.ReadLine()!, Category = (BO.Category)int.Parse(Console.ReadLine()!), Price = double.Parse(Console.ReadLine()!), QuantityInStock = int.Parse(Console.ReadLine()!) });
                    break;
                case 2:
                    Console.Write("הזן ID: ");
                    Console.WriteLine(s_bl.Product.Read(int.Parse(Console.ReadLine()!)));
                    break;
                case 5:
                    s_bl.Product.ReadAll().ToList().ForEach(p => Console.WriteLine(p));
                    break;
            }
        }
        catch (Exception ex) { Console.WriteLine($"שגיאה: {ex.Message}"); }
    }

    private static void SaleMenu()
    {
        try
        {
            Console.WriteLine("1-הוספה | 2-צפייה | 5-הצג הכל");
            int sub = int.Parse(Console.ReadLine()!);
            switch (sub)
            {
                case 1:
                    Console.Write("הזן ID, ID מוצר, אחוז הנחה: ");
                    s_bl.Sale.Create(new Sale { Id = int.Parse(Console.ReadLine()!), IdProduct = int.Parse(Console.ReadLine()!), DiscountPercent = int.Parse(Console.ReadLine()!) });
                    break;
                case 2:
                    Console.Write("הזן ID: ");
                    Console.WriteLine(s_bl.Sale.Read(int.Parse(Console.ReadLine()!)));
                    break;
                case 5:
                    s_bl.Sale.ReadAll().ToList().ForEach(s => Console.WriteLine(s));
                    break;
            }
        }
        catch (Exception ex) { Console.WriteLine($"שגיאה: {ex.Message}"); }
    }
}