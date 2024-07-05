using Microsoft.AspNetCore.Mvc;
using posApp.Models;
using posApp.Service;
using POSwebApi.DtoConveters;
using POSwebApi.Dtos;


namespace POSwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IService<Transaction> _transactionService;
        private readonly IService<Product> _productService;

        public TransactionController(IService<Transaction> transactionService, IService<Product> productService)
        {
            _transactionService = transactionService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionService.GetAllAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Transaction transaction)
        {

            var items= new List<Item>();
            foreach (var product in transaction.products)
            {
                Product existingProduct = await _productService.GetByIdAsync(1);
                Console.WriteLine(existingProduct.name);
                if (existingProduct == null)
                {
                    return BadRequest(new { message = "Products don't exist" });
                }
                Console.WriteLine(existingProduct.quantity);
                Console.WriteLine(product.quantity);

                existingProduct.quantity = existingProduct.quantity - product.quantity;
                Console.WriteLine("product quanity", existingProduct.quantity);
                await _productService.UpdateAsync(existingProduct);


                items.Add(new Item
                {
                    id = product.id,
                    quantity = product.quantity
                });
            
            }
            transaction.products = items;
            await _transactionService.AddAsync(transaction);
            return CreatedAtAction(nameof(GetById), new { id = transaction.id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Transaction transaction)
        {
            if (id != transaction.id)
            {
                return BadRequest();
            }
            await _transactionService.UpdateAsync(transaction);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            await _transactionService.DeleteAsync(transaction.id);
            return NoContent();
        }
    }
}