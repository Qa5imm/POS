using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using posApp;

namespace POSwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        private readonly ProductManager _productManager;
        
        public ProductController(ProductManager productManager)
        {
            _productManager = productManager;
        }


        [HttpGet("all")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            List<Product> products = _productManager.GetProducts();
            return Ok(products);
        }

        [HttpGet("{name}")]
        public ActionResult<Product> GetProduct(string name)
        {
            Product? product = _productManager.FindProduct(name);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            return Ok(product);

        }

        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            var productExist = _productManager.FindProduct(product.name);
            if (productExist != null)
            {
                return Conflict(new { message = "Product already exist" });
            }

            _productManager.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { name = product.name }, product);

        }


        [HttpPut("update")]
        public ActionResult<Product> UpdateProduct(Product product)
        {
            var existingProduct = _productManager.FindProduct(product.name);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            Product? updatedProduct= _productManager.UpdateProduct(product.name, product.price, product.quantity, product.type, product.category);
            return Ok(updatedProduct);
        }

        [HttpPatch("updateQuantity")]

        public ActionResult<Product> UpdatepProductQuantity(string name, int quantity)
        {

            Product? existingProduct = _productManager.UpdateProductQuantity(name, quantity);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            if (existingProduct.quantity < 0)
            {
                return BadRequest(new { message = "Invalid quantity" });
            }

            return Ok(existingProduct);
        }

        [HttpPatch("sellProducts")]
        public ActionResult SellProducts(List<Product> products)
        {
            SellProductsResult result = _productManager.SellProducts(products);
           
            if (result.Success)
            {
                return Ok(new Receipt(result.Products, "User Reciept"));
            }
            return BadRequest(new { message = result.ErrorMessage });

        }

        [HttpDelete("{name}")]
        public ActionResult RemoveRroduct(string name)
        {
            Product? existingProduct = _productManager.FindProduct(name);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            _productManager.RemoveProduct(existingProduct);
            return Ok(new { message = "Product deleted successfully" });
        }

    }
}
