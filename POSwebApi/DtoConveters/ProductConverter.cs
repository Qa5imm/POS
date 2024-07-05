using posApp.Models;
using POSwebApi.Dtos;

namespace POSwebApi.DtoConveters
{
    public static class ProductConverter
    {
        public static ProductDTO ToDTO(Product product)
        {
            return new ProductDTO
            {
                id= product.id,
                name = product.name,
                price = product.price,
                quantity = product.quantity,
                type = product.type,
                category = product.category
            };
        }

        public static List<ProductDTO> ToDTOList(IEnumerable<Product> products)
        {
            return products.Select(p => ToDTO(p)).ToList();
        }

        public static Product ToProduct(ProductDTO productDTO)
        {
            return new Product
            {
                id = productDTO.id,
                name = productDTO.name,
                price = productDTO.price,
                quantity = productDTO.quantity,
                type = productDTO.type,
                category = productDTO.category
            };
        }
        public static List<Product> ToProductList(IEnumerable<ProductDTO> productDTOs)
        {
            return productDTOs.Select(p => ToProduct(p)).ToList();
        }
    }

}
