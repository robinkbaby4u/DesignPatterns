using MyMarket.Business.Domain;

namespace MyMarket.Business.Interfaces
{
    public interface IProductService
    {
        Product GetProductById(int productId);
    }
}
