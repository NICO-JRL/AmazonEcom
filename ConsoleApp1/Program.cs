//using AmazonEcom.Models;
//using Library.eCommerce.Services;

//namespace MyApp
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Welcome to Amazon!");

//            List<Product?> inventory = ProductServiceProxy.Current.Products;

//            char choice;
//            do
//            {
//                Console.WriteLine("\nMENU:");
//                Console.WriteLine("C. Create inventory item");
//                Console.WriteLine("R. Read all inventory items");
//                Console.WriteLine("U. Update an inventory item");
//                Console.WriteLine("D. Delete an inventory item");
//                Console.WriteLine("A. Add item to cart");
//                Console.WriteLine("S. Show shopping cart");
//                Console.WriteLine("X. Remove item from cart");
//                Console.WriteLine("Q. Checkout and Quit");
//
//                string? input = Console.ReadLine();
//                choice = input?[0] ?? ' ';

//                switch (char.ToUpper(choice))
//                {
//                    case 'C':
//                        Console.Write("Product name: ");
//                        string name = Console.ReadLine() ?? "Unnamed";
//                        Console.Write("Price: ");
//                        decimal price = decimal.Parse(Console.ReadLine() ?? "0");
//                        Console.Write("Quantity: ");
//                        int qty = int.Parse(Console.ReadLine() ?? "0");
//                        ProductServiceProxy.Current.AddOrUpdate(new Product { Name = name, Price = price, Quantity = qty });
//                        break;

//                    case 'R':
//                        inventory.ForEach(Console.WriteLine);
//                        break;

//                    case 'U':
//                        Console.Write("Enter product ID to update: ");
//                        int upId = int.Parse(Console.ReadLine() ?? "-1");
//                        var toUpdate = inventory.FirstOrDefault(p => p?.Id == upId);
//                        if (toUpdate != null)
//                        {
//                            Console.Write("New name: ");
//                            toUpdate.Name = Console.ReadLine();
//                            Console.Write("New price: ");
//                            toUpdate.Price = decimal.Parse(Console.ReadLine() ?? "0");
//                            Console.Write("New quantity: ");
//                            toUpdate.Quantity = int.Parse(Console.ReadLine() ?? "0");
//                            ProductServiceProxy.Current.AddOrUpdate(toUpdate);
//                        }
//                        break;

//                    case 'D':
//                        Console.Write("Enter product ID to delete: ");
//                        int delId = int.Parse(Console.ReadLine() ?? "-1");
//                        ProductServiceProxy.Current.Delete(delId);
//                        break;

//                    case 'A':
//                        Console.Write("Enter product ID to add to cart: ");
//                        int addId = int.Parse(Console.ReadLine() ?? "-1");
//                        Console.Write("Enter quantity: ");
//                        int cartQty = int.Parse(Console.ReadLine() ?? "0");
//                        var added = ProductServiceProxy.Current.AddToCart(addId, cartQty);
//                        if (added == null) Console.WriteLine("Error: Not enough stock or invalid product.");
//                        break;

//                   case 'S':
//                       ProductServiceProxy.Current.ShoppingCart.ForEach(Console.WriteLine);
//                        break;

//                    case 'X':
//                        Console.Write("Enter product ID to remove from cart: ");
//                        int remId = int.Parse(Console.ReadLine() ?? "-1");
//                        ProductServiceProxy.Current.RemoveFromCart(remId);
//                        break;

//                    case 'Q':
//                        string receipt = ProductServiceProxy.Current.Checkout();
//                        Console.WriteLine(receipt);
//                        break;

//                    default:
//                        Console.WriteLine("Error: Unknown Command");
//                        break;
//                }
//            } while (char.ToUpper(choice) != 'Q');
//        }
//    }
//}
