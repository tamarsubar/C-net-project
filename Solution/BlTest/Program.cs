using BL.BO;
using BL.BlApi;

namespace BlTest;

class Program
{
    private static readonly IBl s_bl = Factory.Get;

    private static Dictionary<int, Order> ordersMap = new Dictionary<int, Order>();
    private static int? currentActiveId = null;

    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1-Customers | 2-Products | 3-Sales | 4-Order Management | 0-Exit");
            if (!int.TryParse(Console.ReadLine(), out choice)) continue;

            switch (choice)
            {
                case 1: CustomerMenu(); break;
                case 2: ProductMenu(); break;
                case 3: SaleMenu(); break;
                case 4: OrderManagementMenu(); break;
                case 0: Console.WriteLine("Exiting..."); break;
            }
        } while (choice != 0);
    }

    private static void OrderManagementMenu()
    {
        try
        {
            Console.WriteLine("\n--- Order System ---");
            Console.WriteLine("1 - Current Order (Continue) | 2 - Start New Order | 3 - List All Active Carts | 0 - Back");
            if (!int.TryParse(Console.ReadLine(), out int choice)) return;

            switch (choice)
            {
                case 1:
                    if (currentActiveId != null && ordersMap.ContainsKey(currentActiveId.Value))
                    {
                        OrderActionsMenu(currentActiveId.Value);
                    }
                    else
                    {
                        Console.WriteLine("No active session found. Please start a new order.");
                        HandleNewOrder();
                    }
                    break;

                case 2:
                    HandleNewOrder();
                    break;

                case 3:
                    if (ordersMap.Count == 0) Console.WriteLine("No active orders in memory.");
                    foreach (var entry in ordersMap)
                    {
                        Console.WriteLine($"Customer ID: {entry.Key}, Items: {entry.Value.Items?.Count ?? 0}, Total: {entry.Value.TotalPrice}");
                    }
                    break;
            }
        }
        catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
    }

    private static void HandleNewOrder()
    {
        Console.Write("Enter Customer ID: ");
        if (!int.TryParse(Console.ReadLine(), out int custId)) return;

        var customer = s_bl.Customer.Read(custId);
        bool isPreferred = false;

        if (customer != null)
        {
            Console.WriteLine($"Customer identified: {customer.Name}. Club status activated.");
            isPreferred = true; 
        }
        else
        {
            Console.WriteLine("Customer not found. Proceeding as guest (No club benefits).");
        }

        ordersMap[custId] = new Order
        {
            IsPreferredCustomer = isPreferred,
            Items = new List<ProductInOrder>()
        };
        currentActiveId = custId;

        OrderActionsMenu(custId);
    }

    private static void OrderActionsMenu(int custId)
    {
        Order activeOrder = ordersMap[custId];
        bool inMenu = true;

        while (inMenu)
        {
            Console.WriteLine($"\n--- Managing Order for ID: {custId} (Club: {activeOrder.IsPreferredCustomer}) ---");
            Console.WriteLine("1-Add Product | 2-View Cart | 3-Complete Order (DoOrder) | 4-Clear/Cancel Cart | 0-Back to Management");
            if (!int.TryParse(Console.ReadLine(), out int sub)) break;

            switch (sub)
            {
                case 1:
                    try
                    {
                        Console.Write("Product ID: ");
                        int pId = int.Parse(Console.ReadLine()!);
                        Console.Write("Quantity: ");
                        int q = int.Parse(Console.ReadLine()!);

                        var sales = s_bl.Order.AddProductToOrder(activeOrder, pId, q);
                        Console.WriteLine($"Added! \n{sales.Count} sales applied to this item.");
                    }
                    catch (Exception ex) { Console.WriteLine($"Failed to add: {ex.Message}"); }
                    break;

                case 2:
                    Console.WriteLine(activeOrder);
                    break;

                case 3:
                    s_bl.Order.DoOrder(activeOrder);
                    ordersMap.Remove(custId);
                    if (currentActiveId == custId) currentActiveId = null;
                    Console.WriteLine("Order finalized. Inventory updated.");
                    inMenu = false;
                    break;

                case 4:
                    ordersMap.Remove(custId);
                    if (currentActiveId == custId) currentActiveId = null;
                    Console.WriteLine("Cart cleared.");
                    inMenu = false;
                    break;

                case 0:
                    inMenu = false;
                    break;
            }
        }
    }

    private static void CustomerMenu()
    {
        try
        {
            Console.WriteLine("\n--- Customer Menu ---");
            Console.WriteLine("1-Add | 2-View | 3-Update | 4-Delete | 5-Show all");
            int sub = int.Parse(Console.ReadLine()!);
            switch (sub)
            {
                case 1:
                    Customer newCustomer = new Customer();
                    Console.Write("Enter Customer ID: ");
                    newCustomer.Id = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter Full Name: ");
                    newCustomer.Name = Console.ReadLine()!;

                    Console.Write("Enter Address: ");
                    newCustomer.Address = Console.ReadLine()!;

                    Console.Write("Enter Phone Number: ");
                    newCustomer.Phone = Console.ReadLine()!;

                    s_bl.Customer.Create(newCustomer);
                    Console.WriteLine("Customer created successfully!");
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
                    Customer updatedCustomer = new Customer { Id = idToUpdate };

                    Console.Write("Enter New Name: ");
                    updatedCustomer.Name = Console.ReadLine()!;

                    Console.Write("Enter New Address: ");
                    updatedCustomer.Address = Console.ReadLine()!;

                    Console.Write("Enter New Phone Number: ");
                    updatedCustomer.Phone = Console.ReadLine()!;

                    s_bl.Customer.Update(updatedCustomer);
                    Console.WriteLine("Customer updated successfully!");
                    break;
                case 4:
                    Console.Write("Enter ID to delete: ");
                    s_bl.Customer.Delete(int.Parse(Console.ReadLine()!));
                    break;
                case 5:
                    s_bl.Customer.ReadAll().ToList().ForEach(c => Console.WriteLine(c));
                    break;
            }
        }
        catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
    }

    private static void ProductMenu()
    {
        try
        {
            Console.WriteLine("\n--- Product Menu ---");
            Console.WriteLine("1-Add | 2-View | 5-Show All");
            int sub = int.Parse(Console.ReadLine()!);
            switch (sub)
            {
                case 1:
                    Product newProduct = new Product();

                    Console.Write("Enter Product Name: ");
                    newProduct.Name = Console.ReadLine()!;

                    Console.WriteLine("Select Category: 0 - Birthday, 1 - Holiday, 2 - General");
                    Console.Write("Enter Category Number: ");
                    newProduct.Category = (Category)int.Parse(Console.ReadLine()!);

                    Console.Write("Enter Price: ");
                    newProduct.Price = double.Parse(Console.ReadLine()!);

                    Console.Write("Enter Quantity in Stock: ");
                    newProduct.QuantityInStock = int.Parse(Console.ReadLine()!);

                    s_bl.Product.Create(newProduct);
                    Console.WriteLine("Product created successfully!");
                    break;
                case 2:
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
            Console.WriteLine("\n--- Sale Menu ---");
            Console.WriteLine("1-Add | 2-View | 3-Show All");
            int sub = int.Parse(Console.ReadLine()!);
            switch (sub)
            {
                case 1:
                    Console.Write("Enter ID, Product ID, Count for Sale, Total Price: ");
                    s_bl.Sale.Create(new Sale { Id = int.Parse(Console.ReadLine()!), IdProduct = int.Parse(Console.ReadLine()!), CountForSale = int.Parse(Console.ReadLine()!), TotalPrice = double.Parse(Console.ReadLine()!) });
                    break;
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