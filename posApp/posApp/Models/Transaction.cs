using System.ComponentModel.DataAnnotations;

namespace posApp.Models
{
    public class Transaction    
    {
        [Key]
        public int id { get; set; }

        public List<Item> products { get; set; }
        public decimal totalAmount { get; set; }

        public string description { get; set; } = string.Empty;
   
    }

   
}
