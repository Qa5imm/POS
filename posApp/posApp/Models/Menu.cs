using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posApp.Models
{
    public static class Menu
    {
        /*public static void CashierMenu()
        {
            while (true)
            {
                Console.WriteLine("Cashier Menu:");
                Console.WriteLine("1. Add Product to Sale");
                Console.WriteLine("2. Calculate Total Amount");
                Console.WriteLine("3. Generate Receipt");
                Console.WriteLine("4. Logout");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter product name: ");
                        var name = Console.ReadLine();
                        Console.Write("Enter quantity: ");
                        var quantity = Convert.ToInt32(Console.ReadLine());
                        SalesTransaction.AddProductToSale(name, quantity);
                        break;
                    case "2":
                        var totalAmount = SalesTransaction.CalculateTotalAmount();
                        Console.WriteLine($"Total Amount: {totalAmount}");
                        break;
                    case "3":
                        SalesTransaction.GenerateReceipt();
                        break;
                    case "4":
                        return;
                }
            }
        }

        public static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Remove Product");
                Console.WriteLine("4. View Products");
                Console.WriteLine("5. Set User Role");
                Console.WriteLine("6. Logout");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter name: ");
                        var name = Console.ReadLine();
                        Console.Write("Enter price: ");
                        var price = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter quantity: ");
                        var quantity = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter type: ");
                        var type = Console.ReadLine();
                        Console.Write("Enter category: ");
                        var category = Console.ReadLine();
                        ProductManager.AddProduct(new Product { name = name, price = price, quantity = quantity, type = type, category = category });
                        break;
                    case "2":
                        Console.Write("Enter name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter price: ");
                        price = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter quantity: ");
                        quantity = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter type: ");
                        type = Console.ReadLine();
                        Console.Write("Enter category: ");
                        category = Console.ReadLine();
                        ProductManager.UpdateProduct(name, price, quantity, type, category);
                        break;
                    case "3":
                        Console.Write("Enter name: ");
                        name = Console.ReadLine();
*//*                        ProductManager.RemoveProduct(name);
*//*                        break;
                    case "4":
                        ProductManager.ViewProducts();
                        break;
                    case "5":
                        Console.Write("Enter email: ");
                        var email = Console.ReadLine();
                        Console.Write("Enter role: ");
                        var role = Console.ReadLine();
                        UserManager.UpdateUserRole(email, role);
                        break;
                    case "6":
                        return;
                }
            }
        }*/
    }
}
