namespace POSwebApi.Dtos
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public decimal price { get; set; } = 0;
        public int quantity { get; set; } = 0;

    }
}
