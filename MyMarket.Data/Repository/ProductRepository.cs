using MyMarket.Data.Entities;
using MyMarket.Data.Interfaces;

namespace MyMarket.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductById(int productId)
        {
            return new Product()
            {
                Description = "Intel processor, 16 gb RAM",
                Id = productId,
                ProductImage = "https://cdn.mos.cms.futurecdn.net/A4GDK27VMnz6LtFDy9yzk-970-80.jpg.webp",
                ProductName = "Macbook pro"
            };
        }
    }
}
