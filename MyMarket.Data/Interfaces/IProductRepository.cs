using MyMarket.Data.Entities;

namespace MyMarket.Data.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductById(int productId);
    }
}
