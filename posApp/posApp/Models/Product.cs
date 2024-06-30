
using System.ComponentModel.DataAnnotations;

namespace posApp.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public decimal price { get; set; } = 0;
        public int quantity { get; set; } = 0;

    }
}
