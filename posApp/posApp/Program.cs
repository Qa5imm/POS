using posApp;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        /* // Sample data
         UserManager.AddUser(new User { name = "Admin", email = "admin@pos.com"    , password = "admin", role = "admin" });
         UserManager.AddUser(new User { name = "Cashier", email = "cashier@pos.com", password = "cashier", role = "cashier" });
         ProductManager.AddProduct(new Product { name = "Apple", price = 100, quantity = 12, category = "Fruit", type = "Food" });
         ProductManager.AddProduct(new Product { name = "Oranges", price = 150, quantity = 12, category = "Fruit", type = "Food" });



         while (true)
         {
             Console.WriteLine("1. Login");
             Console.WriteLine("2. Register User");
             Console.WriteLine("3. Exit");
             var choice = Console.ReadLine();

             switch (choice)
             {
                 case "1":
                     Console.Write("Enter email: ");
                     var email = Console.ReadLine();
                     Console.Write("Enter password: ");
                     var password = Console.ReadLine();

                     var user = UserManager.AuthenticateUser(email, password);
                     if (user != null)
                     {
                         Console.WriteLine($"Welcome, {user.name}");
                         if (user.role == "admin")
                         {
                             Menu.AdminMenu();
                         }
                         else if (user.role == "cashier")
                         {
                             Menu.CashierMenu();
                         }
                     }
                     else
                     {
                         Console.WriteLine("Invalid email or password.");
                     }
                     break;
                 case "2":
                     Console.Write("Enter name: ");
                     var name = Console.ReadLine();
                     Console.Write("Enter email: ");
                     email = Console.ReadLine();
                     Console.Write("Enter password: ");
                     password = Console.ReadLine();
                     Console.Write("Enter role (admin/cashier): ");
                     var role = Console.ReadLine();
                     UserManager.AddUser( new User { name=name, email=email, password=password, role=role });
                     break;
                 case "3":
                     return;
             }
         }
     }
 */
    }

   
}
