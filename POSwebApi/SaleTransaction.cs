
namespace POSwebApi
{
    public static class SalesTransaction
    {
        public static List<Product> CurrentSale = new List<Product>();

        public static void AddProductToSale(string name, int quantity)
        {
            var product = DataContext.products.Find(p => p.name == name);
            if (product != null && product.quantity >= quantity)
            {
                CurrentSale.Add(new Product { name = product.name, price = product.price, quantity = quantity, type = product.type, category = product.category });
                product.quantity -= quantity;
                Console.WriteLine("Product added to the sale.");
            }
            else
            {
                Console.WriteLine("Product not available or insufficient quantity.");
            }
        }

        public static decimal CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (var product in CurrentSale)
            {
                total += product.price * product.quantity;
            }
            return total;
        }

        public static void GenerateReceipt()
        {
            Console.WriteLine("Receipt:");
            foreach (var product in CurrentSale)
            {
                Console.WriteLine($"Product: {product.name}, quantity: {product.quantity}, price: {product.price}, Total: {product.price * product.quantity}");
            }
            Console.WriteLine($"Total Amount: {CalculateTotalAmount()}");
            CurrentSale.Clear();
        }
    }

}
