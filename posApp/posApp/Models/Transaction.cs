using System.ComponentModel.DataAnnotations;

namespace posApp.Models
{
    public class Transaction    
    {
        [Key]
        public int id { get; set; }

        public List<Product> products { get; set; } = new List<Product>();
        public decimal totalAmount { get; set; }

        public string description { get; set; } = string.Empty;
   
    }
}
