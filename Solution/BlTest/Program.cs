using BL.BO;
using BL.BlApi;

namespace BlTest;

class Program
{
    private static readonly IBl s_bl = Factory.Get;

    private static Dictionary<int, Order> ordersMap = new();
    private static int? currentActiveId = null;

    static void Main(string[] args)
    {
        int choose;

        do
        {
            choose = PrintMainMenu();

            switch (choose)
            {
                case 1:
                    PrintSubMenu("customers");
                    break;

                case 2:
                    PrintSubMenu("products");
                    break;

                case 3:
                    PrintSubMenu("sales");
                    break;

                case 4:
                    OrderManagementMenu();
                    break;

                case 0:
                    Console.WriteLine("Goodbye.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choose != 0);
    }

    public static int PrintMainMenu()
    {
        try
        {
            Console.WriteLine();
            Console.WriteLine("------ MAIN MENU ------");
            Console.WriteLine("customers : 1");
            Console.WriteLine("products  : 2");
            Console.WriteLine("sales     : 3");
            Console.WriteLine("orders    : 4");
            Console.WriteLine("exit      : 0");

            return int.Parse(Console.ReadLine()!);
        }
        catch
        {
            return -1;
        }
    }

    public static int ShowChoose(string s)
    {
        Console.WriteLine($"add {s} : 1");
        Console.WriteLine($"show {s} : 2");
        Console.WriteLine($"update {s} : 3");
        Console.WriteLine($"delete {s} : 4");
        Console.WriteLine($"show all {s}s : 5");

        return int.Parse(Console.ReadLine()!);
    }

    public static void PrintSubMenu(string s)
    {
        try
        {
            int choose;

            switch (s)
            {
                case "customers":

                    choose = ShowChoose("customer");

                    switch (choose)
                    {
                        case 1:
                            AddCustomer();
                            break;

                        case 2:
                            ReadCustomer();
                            break;

                        case 3:
                            UpdateCustomer();
                            break;

                        case 4:
                            DeleteCustomer();
                            break;

                        case 5:
                            ReadAllCustomers();
                            break;
                    }

                    break;

                case "products":

                    choose = ShowChoose("product");

                    switch (choose)
                    {
                        case 1:
                            AddProduct();
                            break;

                        case 2:
                            ReadProduct();
                            break;

                        case 3:
                            UpdateProduct();
                            break;

                        case 4:
                            DeleteProduct();
                            break;

                        case 5:
                            ReadAllProducts();
                            break;
                    }

                    break;

                case "sales":

                    choose = ShowChoose("sale");

                    switch (choose)
                    {
                        case 1:
                            AddSale();
                            break;

                        case 2:
                            ReadSale();
                            break;

                        case 3:
                            UpdateSale();
                            break;

                        case 4:
                            DeleteSale();
                            break;

                        case 5:
                            ReadAllSales();
                            break;
                    }

                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    private static void AddCustomer()
    {
        try
        {
            Customer c = new();

            Console.WriteLine("Enter customer id");
            c.Id = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter customer name");
            c.Name = Console.ReadLine()!;

            Console.WriteLine("Enter customer address");
            c.Address = Console.ReadLine()!;

            Console.WriteLine("Enter customer phone");
            c.Phone = Console.ReadLine()!;

            s_bl.Customer.Create(c);

            Console.WriteLine("Customer added successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ReadCustomer()
    {
        Console.WriteLine("Enter customer id");
        int id = int.Parse(Console.ReadLine()!);

        Console.WriteLine(s_bl.Customer.Read(id));
    }

    private static void UpdateCustomer()
    {
        try
        {
            Customer c = new();

            Console.WriteLine("Enter customer id");
            c.Id = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter customer name");
            c.Name = Console.ReadLine()!;

            Console.WriteLine("Enter customer address");
            c.Address = Console.ReadLine()!;

            Console.WriteLine("Enter customer phone");
            c.Phone = Console.ReadLine()!;

            s_bl.Customer.Update(c);

            Console.WriteLine("Customer updated successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void DeleteCustomer()
    {
        try
        {
            Console.WriteLine("Enter customer id");
            int id = int.Parse(Console.ReadLine()!);

            s_bl.Customer.Delete(id);

            Console.WriteLine("Deleted successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ReadAllCustomers()
    {
        foreach (var item in s_bl.Customer.ReadAll())
        {
            Console.WriteLine(item);
            Console.WriteLine("---------------------------");
        }
    }


    private static void AddProduct()
    {
        try
        {
            Product p = new();

            Console.WriteLine("Enter product name");
            p.Name = Console.ReadLine()!;

            Console.WriteLine("Enter category");
            p.Category = (Category)Enum.Parse(typeof(Category), Console.ReadLine()!);

            Console.WriteLine("Enter product price");
            p.Price = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter quantity in stock");
            p.QuantityInStock = int.Parse(Console.ReadLine()!);

            s_bl.Product.Create(p);

            Console.WriteLine("Product added successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ReadProduct()
    {
        Console.WriteLine("Enter product id");
        int id = int.Parse(Console.ReadLine()!);

        Console.WriteLine(s_bl.Product.Read(id));
    }

    private static void UpdateProduct()
    {
        try
        {
            Product p = new();

            Console.WriteLine("Enter product name");
            p.Name = Console.ReadLine()!;

            Console.WriteLine("Enter category");
            p.Category = (Category)Enum.Parse(typeof(Category), Console.ReadLine()!);

            Console.WriteLine("Enter product price");
            p.Price = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter quantity in stock");
            p.QuantityInStock = int.Parse(Console.ReadLine()!);

            s_bl.Product.Update(p);

            Console.WriteLine("Product updated successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void DeleteProduct()
    {
        try
        {
            Console.WriteLine("Enter product id");
            int id = int.Parse(Console.ReadLine()!);

            s_bl.Product.Delete(id);

            Console.WriteLine("Deleted successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ReadAllProducts()
    {
        foreach (var item in s_bl.Product.ReadAll())
        {
            Console.WriteLine(item);
            Console.WriteLine("---------------------------");
        }
    }


    private static void AddSale()
    {
        try
        {
            Sale s = new();

            Console.WriteLine("Enter product id");
            s.IdProduct = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter count for sale");
            s.CountForSale = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter total price");
            s.TotalPrice = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Need club? true/false");
            s.NeedClub = bool.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter start date");
            s.StartSale = DateTime.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter finish date");
            s.FinishSale = DateTime.Parse(Console.ReadLine()!);

            s_bl.Sale.Create(s);

            Console.WriteLine("Sale added successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ReadSale()
    {
        Console.WriteLine("Enter sale id");
        int id = int.Parse(Console.ReadLine()!);

        Console.WriteLine(s_bl.Sale.Read(id));
    }

    private static void UpdateSale()
    {
        try
        {
            Sale s = new();

            Console.WriteLine("Enter product id");
            s.IdProduct = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter count for sale");
            s.CountForSale = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter total price");
            s.TotalPrice = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Need club? true/false");
            s.NeedClub = bool.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter start date");
            s.StartSale = DateTime.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter finish date");
            s.FinishSale = DateTime.Parse(Console.ReadLine()!);

            s_bl.Sale.Update(s);

            Console.WriteLine("Sale updated successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void DeleteSale()
    {
        try
        {
            Console.WriteLine("Enter sale id");
            int id = int.Parse(Console.ReadLine()!);

            s_bl.Sale.Delete(id);

            Console.WriteLine("Deleted successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ReadAllSales()
    {
        foreach (var item in s_bl.Sale.ReadAll())
        {
            Console.WriteLine(item);
            Console.WriteLine("---------------------------");
        }
    }


    private static void OrderManagementMenu()
    {
        try
        {
            Console.WriteLine();
            Console.WriteLine("------ ORDER MENU ------");
            Console.WriteLine("1 - Continue current order");
            Console.WriteLine("2 - Start new order");
            Console.WriteLine("3 - Show all active carts");
            Console.WriteLine("0 - Back");

            int choose = int.Parse(Console.ReadLine()!);

            switch (choose)
            {
                case 1:

                    if (currentActiveId != null &&
                        ordersMap.ContainsKey(currentActiveId.Value))
                    {
                        OrderActionsMenu(currentActiveId.Value);
                    }
                    else
                    {
                        Console.WriteLine("No active order");
                    }

                    break;

                case 2:
                    HandleNewOrder();
                    break;

                case 3:

                    foreach (var item in ordersMap)
                    {
                        Console.WriteLine($"customer id : {item.Key}");
                        Console.WriteLine(item.Value);
                    }

                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void HandleNewOrder()
    {
        try
        {
            Console.WriteLine("Enter customer id");
            int customerId = int.Parse(Console.ReadLine()!);

            var customer = s_bl.Customer.Read(customerId);

            bool isPreferred = customer != null;

            if (customer != null)
            {
                Console.WriteLine($"Hello {customer.Name}");
            }
            else
            {
                Console.WriteLine("Guest customer");
            }

            ordersMap[customerId] = new Order
            {
                IsPreferredCustomer = isPreferred,
                Items = new List<ProductInOrder>()
            };

            currentActiveId = customerId;

            OrderActionsMenu(customerId);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void OrderActionsMenu(int customerId)
    {
        Order order = ordersMap[customerId];

        bool run = true;

        while (run)
        {
            Console.WriteLine();
            Console.WriteLine("------ ORDER ACTIONS ------");
            Console.WriteLine("1 - Add product");
            Console.WriteLine("2 - Show cart");
            Console.WriteLine("3 - Complete order");
            Console.WriteLine("4 - Cancel order");
            Console.WriteLine("0 - Back");

            int choose = int.Parse(Console.ReadLine()!);

            switch (choose)
            {
                case 1:

                    try
                    {
                        Console.WriteLine("Enter product id");
                        int productId = int.Parse(Console.ReadLine()!);

                        Console.WriteLine("Enter quantity");
                        int quantity = int.Parse(Console.ReadLine()!);

                        var sales =
                            s_bl.Order.AddProductToOrder(order, productId, quantity);

                        Console.WriteLine($"{sales.Count} sales applied");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case 2:

                    Console.WriteLine(order);

                    break;

                case 3:

                    try
                    {
                        s_bl.Order.DoOrder(order);

                        Console.WriteLine("Order completed successfully");

                        ordersMap.Remove(customerId);

                        if (currentActiveId == customerId)
                            currentActiveId = null;

                        run = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case 4:

                    ordersMap.Remove(customerId);

                    if (currentActiveId == customerId)
                        currentActiveId = null;

                    Console.WriteLine("Order cancelled");

                    run = false;

                    break;

                case 0:

                    run = false;

                    break;
            }
        }
    }
}
