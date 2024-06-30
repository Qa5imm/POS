namespace posApp.Models
{
    public class Receipt
    {
        private static int _count = 0;
        public int id { get; set; }

        public List<Product> products { get; set; }

        public decimal totalAmount { get; set; }

        public string description { get; set; }

        public Receipt(List<Product> products, string description)
        {

            id = ++_count;
            this.products = products;
            totalAmount = products.Sum(product => product.quantity * product.price);
            this.description = description;
        }
    }
}
