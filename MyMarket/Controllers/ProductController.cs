using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMarket.Business.Domain;
using MyMarket.Business.Interfaces;
using MyMarket.Business.Services;
using MyMarket.ViewModels;
using System;
using System.Text;

namespace MyMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        private  ICurrencyService _currencyService;

        public ProductController(IProductService productService, ICurrencyService currencyService, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;
            _currencyService = currencyService;
        }

        // GET: ProductController/Create
        public ActionResult SelectProduct()
        {
            try
            {
                Product product = _productService.GetProductById(1);

                ProductViewModel productModel = new ProductViewModel()
                {
                    Product = product
                };

                return View(productModel);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "An error occured");
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectProduct(ProductViewModel productViewModel)
        {
            try
            {
                return RedirectToAction("CustomerBalance", productViewModel);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "An error occured");
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: ProductController/Create
        public ActionResult CustomerBalance(ProductViewModel productViewModel)
        {
            try
            {
                switch(productViewModel.CustomerCurrency)
                {
                    case Currency.USD:
                        _currencyService = new USDCurrencyService();
                        break;
                    case Currency.EUR:
                        _currencyService = new EURCurrencyService();
                        break;
                    case Currency.GBP:
                        _currencyService = new GBPCurrencyService();
                        break;
                    default:
                        throw new Exception("Invalid operation");

                }

                double productConvertedAmount = _currencyService.GetConvertedAmount(productViewModel.ProductPrice, productViewModel.ProductCurrency);

                double balance = productViewModel.CustomerAmount - productConvertedAmount;
                StringBuilder denominations = new StringBuilder();

                if (balance > 0)
                {
                    denominations = _currencyService.GetDenominations(balance);
                }

                productViewModel.ProductPrice = productConvertedAmount;
                productViewModel.BalanceAmount = Math.Round(balance,2);
                productViewModel.Denominations = new HtmlString(denominations.ToString());

                return View(productViewModel);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "An error occured");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
