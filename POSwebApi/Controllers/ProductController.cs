using Microsoft.AspNetCore.Mvc;
using posApp.Models;
using posApp.Service;
using POSwebApi.DtoConveters;
using POSwebApi.Dtos;

namespace posApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IService<Product> _productService;

        public ProductController(IService<Product> service)
        {
            _productService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            List<ProductDTO> productsDTO = ProductConverter.ToDTOList(products);
            return Ok(productsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ProductDTO productDTO = ProductConverter.ToDTO(product);
            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            await _productService.AddAsync(product);
            ProductDTO productDTO = ProductConverter.ToDTO(product);
            return CreatedAtAction(nameof(GetById), new { id = product.id }, productDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Update the product
            await _productService.UpdateAsync(product);
            ProductDTO productDTO = ProductConverter.ToDTO(product);
            return Ok(productDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(id);
            return Ok();
        }
    }
}
