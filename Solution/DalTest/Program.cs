using DO;
using DalApi;
using Dal;
using System;
using System.ComponentModel;
using System.Data.Common;
namespace DalTest
{
    internal class Program
    {
        static readonly DalApi.IDal s_dal = DalApi.Factory.Get;
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to initialize data? (y/n)");
            string ans = Console.ReadLine();
            if (ans == "y")
            {        try
                {
                    Initialization.Initialize();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int choose;
            do
            {
                choose = PrintMainMenu();
                switch (choose)
                {
                    case 1: PrintSubMemu("customers"); break;
                    case 2: PrintSubMemu("products"); break;
                    case 3: PrintSubMemu("sales"); break;
                    case 4: Console.WriteLine("Goodbye."); return;
                    default: break;
                }
            } while (choose != 4);
        }
        public static int PrintMainMenu()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t main menu");
                Console.WriteLine("customers: 1");
                Console.WriteLine("products: 2");
                Console.WriteLine("sales: 3");
                Console.WriteLine("exit: 4");
                int choose = int.Parse(Console.ReadLine());
                return choose;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }


        public static int ShowChoose(string s)
        {
            try
            {
                int num;
                Console.WriteLine("add {0} : 1", s);
                Console.WriteLine("show {0}: 2", s);
                Console.WriteLine("update {0}: 3", s);
                Console.WriteLine("delete {0}: 4", s);
                Console.WriteLine("show all {0}s list: 5", s);

                num = int.Parse(Console.ReadLine());
                return num;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }
        public static void PrintSubMemu(string s)
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
                            case 1: AddCustomer(); break;
                            case 2: Read(s_dal.Customer); break;
                            case 3: UpdateCustomer(); break;
                            case 4: Delete(s_dal.Customer); break;
                            case 5: ReadAll(s_dal.Customer); break;
                            default:
                                Console.WriteLine("Error. Please select again.");
                                PrintSubMemu(s);
                                break;
                        }
                        break;
                    case "products":
                        choose = ShowChoose("product");
                        switch (choose)
                        {
                            case 1: AddProduct(); break;
                            case 2: Read(s_dal.Product); break;
                            case 3: UpdateProduct(); break;
                            case 4: Delete(s_dal.Product); break;
                            case 5: ReadAll(s_dal.Product); break;

                            default:
                                Console.WriteLine("Error. Please select again.");
                                PrintSubMemu(s);
                                break;
                        }
                        break;
                    case "sales":
                        choose = ShowChoose("sale");
                        switch (choose)
                        {
                            case 1: AddSale(); break;
                            case 2: Read(s_dal.Sale); break;
                            case 3: UpdateSale(); break;
                            case 4: Delete(s_dal.Sale); break;
                            case 5: ReadAll(s_dal.Sale); break;

                            default:
                                Console.WriteLine("Error. Please select again.");
                                PrintSubMemu(s);
                                break;
                        }
                        break;
                    default:
                        PrintMainMenu();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private static void AddCustomer()
        {
            try
            {
                Console.WriteLine("insert customer id");
                int customerId = int.Parse(Console.ReadLine());
                Console.WriteLine("insert customer name");
                string customerName = Console.ReadLine();
                Console.WriteLine("insert customer adress");
                string customerAddress = Console.ReadLine();
                Console.WriteLine("insert customer's phone");
                string customerPhone = Console.ReadLine();


                s_dal.Customer.Create(new Customer(customerId, customerName, customerAddress, customerPhone));
                Console.WriteLine("for add more customer press :1, for out press: 2");
                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                    AddCustomer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        private static void AddProduct(int id = 0)
        {
            try
            {
                Console.WriteLine("insert product name ");
                string productName = Console.ReadLine();
                Console.WriteLine("insert product category");
                string categoryInput = Console.ReadLine();
                if (!Enum.TryParse(categoryInput, true, out category productCategory))
                {
                    productCategory = category.birthDay;
                }
                Console.WriteLine("insert product price");
                double productPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("imsert product Quantity In Stock ");
                int productQuantityInStock = int.Parse(Console.ReadLine());

                s_dal.Product.Create(new Product(id, productName, productCategory, productPrice, productQuantityInStock));
                Console.WriteLine("for add more product press :1, for out press: 2");
                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                    AddProduct();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        private static void AddSale(int id = 0)
        {
            try
            {
                Console.WriteLine("insert id Product for sale");
                int saleProductforsale = int.Parse(Console.ReadLine());
                Console.WriteLine("insert count for sale to get the sale");
                int saleCountforsale = int.Parse(Console.ReadLine());
                Console.WriteLine("insert total price");
                double saleTotalPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("need club to get the sale? yes/no");
                bool saleNeedClub = bool.Parse(Console.ReadLine());
                Console.WriteLine("insert start_date sale ");
                DateTime saleStartSale = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("הכנס תאריך סיום המבצע");
                DateTime saleFinishSale = DateTime.Parse(Console.ReadLine());
                s_dal.Sale.Create(new Sale(id, saleProductforsale, saleCountforsale, saleTotalPrice, saleNeedClub, saleStartSale, saleFinishSale));
                Console.WriteLine("for add more sale press :1, for out press: 2");
                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                    AddSale();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        private static void UpdateCustomer()
        {
            try
            {
                Console.WriteLine("Enter a customer ID to update.");
                int customerIdupdate = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter an updated customer name.");
                string customerName = Console.ReadLine();
                Console.WriteLine(" Enter an updated customer address.");
                string customerAddress = Console.ReadLine();
                Console.WriteLine(" Enter the customer's updated cell phone number.");
                string customerPhone = Console.ReadLine();

                s_dal.Customer.Update(new Customer(customerIdupdate, customerName, customerAddress, customerPhone));
                Console.WriteLine("for update more customer press :1, for out press: 2");
                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                    UpdateCustomer();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static void UpdateProduct()
        {
            try
            {
                Console.WriteLine(" Enter product ID number to update");
                int productId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter product name");
                string productName = Console.ReadLine();
                Console.WriteLine("Enter a product category (birthday, holiday):");
                string categoryInput = Console.ReadLine();
                if (!Enum.TryParse(categoryInput, true, out category productCategory))
                {
                    productCategory = category.birthDay;
                }
                Console.WriteLine("Enter product price");
                double productPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter quantity of product in stock");
                int productQuantityInStock = int.Parse(Console.ReadLine());

                s_dal.Product.Update(new Product(productId, productName, productCategory, productPrice, productQuantityInStock));
                Console.WriteLine("for update more product press :1, for out press: 2");
                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                    UpdateProduct();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static void UpdateSale(int id = 0)
        {
            try
            {
                Console.WriteLine("Enter product ID for promotion to update");
                int saleProductforsale = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the quantity of products to receive the offer.");
                int saleCountforsale = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the total price for the sale. ");
                double saleTotalPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("Is the offer intended for all customers or only for club customers? yes/no");
                bool saleNeedClub = bool.Parse(Console.ReadLine());
                Console.WriteLine("Enter the start date of the promotion.");
                DateTime saleStartSale = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the end date of the promotion.");
                DateTime saleFinishSale = DateTime.Parse(Console.ReadLine());
                s_dal.Sale.Update(new Sale(id, saleProductforsale, saleCountforsale, saleTotalPrice, saleNeedClub, saleStartSale, saleFinishSale));
                Console.WriteLine("for update more sale press :1, for out press: 2");
                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                    UpdateSale();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        private static void Read<T>(ICrud<T> crud)
        {
            Console.WriteLine("insert id");
            int id = int.Parse(Console.ReadLine());
            var item = crud.Read(id);
            if (item != null)
                Console.WriteLine(item);
            else Console.WriteLine("not found");
        }
        private static void Delete<T>(ICrud<T> crud)
        {
            Console.WriteLine("insert id");
            int id = int.Parse(Console.ReadLine());
            try { crud.Delete(id); Console.WriteLine("Deleted successfully."); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }


        private static void ReadAll<T>(ICrud<T> icrud) where T : class
        {
            foreach (var item in icrud.ReadAll())
            {
                Console.WriteLine(item + "\n---------------------------------");

            }


        }






    }
}
