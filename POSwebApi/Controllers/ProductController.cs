using Microsoft.AspNetCore.Mvc;
using posApp.Models;
using posApp.Services;
using posApp.Response;
using POSwebApi.Dtos;
using POSwebApi.DtoConveters;

namespace POSwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productManager)
        {
            _productService = productManager;
        }


        [HttpGet("all")]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            List<Product> products = _productService.GetProducts();
            return Ok(ProductConverter.ToDTOList(products));
        }

        [HttpGet("{name}")]
        public ActionResult<ProductDTO> GetProduct(string name)
        {
            Product? product = _productService.FindProduct(name);

            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            
            return Ok(ProductConverter.ToDTO(product));

        }

        [HttpPost]
        public ActionResult<ProductDTO> AddProduct(ProductDTO productDTO)
        {
            var existingProduct = _productService.FindProduct(productDTO.name);
            if (existingProduct != null)
            {
                return Conflict(new { message = "Product already exist" });
            }

            _productService.AddProduct(ProductConverter.ToProduct(productDTO));
            return CreatedAtAction(nameof(GetProduct), new { name = productDTO.name }, productDTO);

        }


        [HttpPut("update")]
        public ActionResult<ProductDTO> UpdateProduct(ProductDTO productDTO)
        {
            var existingProduct = _productService.FindProduct(productDTO.name);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            Product? updatedProduct = _productService.UpdateProduct(productDTO.name, productDTO.price, productDTO.quantity, productDTO.type, productDTO.category);
            return Ok(ProductConverter.ToDTO(updatedProduct));
        }

        [HttpPatch("updateQuantity")]

        public ActionResult<ProductDTO> UpdatepProductQuantity(string name, int quantity)
        {

            Product? existingProduct = _productService.UpdateProductQuantity(name, quantity);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            if (existingProduct.quantity < 0)
            {
                return BadRequest(new { message = "Invalid quantity" });
            }

            return Ok(ProductConverter.ToDTO(existingProduct));
        }

        [HttpPatch("sellProducts")]
        public ActionResult SellProducts(List<ProductDTO> productDTOs)
        {
            SellProductsResult result = _productService.SellProducts(ProductConverter.ToProductList(productDTOs));

            if (result.Success)
            {
                return Ok(new Receipt(result.Products, "User Reciept"));
            }
            return BadRequest(new { message = result.ErrorMessage });

        }

        [HttpDelete("{name}")]
        public ActionResult RemoveRroduct(string name)
        {
            Product? existingProduct = _productService.FindProduct(name);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            _productService.RemoveProduct(existingProduct);
            return Ok(new { message = "Product deleted successfully" });
        }

    }
}
