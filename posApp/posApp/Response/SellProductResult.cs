using posApp.Models;

namespace posApp.Response
{
    public class SellProductsResult
    {
        public List<Product> Products { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }

        public SellProductsResult()
        {
            Products = new List<Product>();
            ErrorMessage = string.Empty;
            Success = true;
        }
    }
}
