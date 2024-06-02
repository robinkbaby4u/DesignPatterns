using Moq;
using MyMarket.Business.Interfaces;
using MyMarket.Business.Services;
using MyMarket.Data.Interfaces;
using Xunit;
using ProductEntity = MyMarket.Data.Entities.Product;

namespace MyMarket.UnitTests
{
    public class ProductServeTests
    {
        private readonly IProductService _productService;
        private readonly Mock<IProductRepository> _productRepository;

        public ProductServeTests()
        {
            _productRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepository.Object);
        }

        [Fact]
        public void GetProductById_Test()
        {
            //Arrange
            ProductEntity productEntity = new ProductEntity()
            {
                Description = "Intel processor, 16 gb RAM",
                Id = 1,
                ProductImage = "https://cdn.mos.cms.futurecdn.net/A4GDK27VMnz6LtFDy9yzk-970-80.jpg.webp",
                ProductName = "Macbook pro"
            };
            int productId = 1;

            _productRepository.Setup(x => x.GetProductById(It.IsAny<int>())).Returns(productEntity);

            //act
            Business.Domain.Product sut = _productService.GetProductById(productId);

            //Assert
            Assert.Equal(productEntity.ProductImage, sut.ProductImage);
            Assert.Equal(productEntity.ProductName, sut.ProductName);

        }
    }
}
