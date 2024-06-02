using MyMarket.Business.Domain;
using MyMarket.Business.Interfaces;
using MyMarket.Data.Interfaces;

namespace MyMarket.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProductById(int productId)
        {
            var productEntity = _productRepository.GetProductById(productId);

            Product product = new Product()
            {
                Id = productEntity.Id,
                Description = productEntity.Description,
                ProductImage = productEntity.ProductImage,
                ProductName = productEntity.ProductName
            };

            return product;
           
        }
    }
}
