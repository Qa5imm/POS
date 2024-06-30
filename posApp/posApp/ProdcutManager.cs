using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Xml.Linq;


namespace posApp
{
    public  class ProductManager
    {
        private readonly DataContext _dtContext;

        public ProductManager(DataContext context)
        {
            _dtContext = context;
        }

        public List<Product> GetProducts()
        {
            return _dtContext.products.ToList();
        }

        public  Product? FindProduct(string name)
        {
            return _dtContext.products.FirstOrDefault(p => p.name == name);
        }

        public void AddProduct(Product product)
        {

            _dtContext.products.Add(product);
            _dtContext.SaveChanges();
            /*Console.WriteLine("Product added successfully.");*/
        }

        public Product? UpdateProduct(string name, decimal price, int quantity, string type, string category)
        {
            var existingProduct = FindProduct(name);
            if (existingProduct != null)
            {
                existingProduct.price = price;
                existingProduct.quantity = quantity;
                existingProduct.type = type;
                existingProduct.category = category;
                _dtContext.SaveChanges();
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
            return existingProduct;
        }



        public void RemoveProduct(Product product)
        {
            Product? existingProduct = FindProduct(product.name);
            if (existingProduct != null)
            {
                _dtContext.products.Remove(existingProduct);    
                _dtContext.SaveChanges();
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public Product? UpdateProductQuantity(string name, int quantity)
        {
            Product? existingProduct = FindProduct(name);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.quantity = quantity;
            _dtContext.SaveChanges();

            return existingProduct;
        }


        public SellProductsResult SellProducts(List<Product> soldProducts)
        {
            SellProductsResult result = new SellProductsResult();
            List<Product>? initialProducts = JsonConvert.DeserializeObject<List<Product>>(JsonConvert.SerializeObject(_dtContext.products.ToList()));

            foreach (Product product in soldProducts)
            {
                if (product.quantity <= 0)
                {
                    result.ErrorMessage = "Invalid request";
                    result.Success = false;
                    return result;

                }
                Product? existingProduct = FindProduct(product.name);

                existingProduct.quantity -= product.quantity;
                _dtContext.SaveChanges();


                if (existingProduct.quantity < 0)
                {
                    // Rollback changes
                    _dtContext.products.RemoveRange(_dtContext.products);
                    _dtContext.products.AddRange(initialProducts);
                    _dtContext.SaveChanges();

                    result.ErrorMessage = "Insufficient quantity";
                    result.Success = false;
                    return result;
                }
                result.Products.Add(product);

            }
            return result;
        }
        public void ViewProducts()
        {
            foreach (var product in _dtContext.products)
            {
                Console.WriteLine($"name: {product.name}, price: {product.price}, quantity: {product.quantity}, type: {product.type}, category: {product.category}");
            }
        }
    }

}
