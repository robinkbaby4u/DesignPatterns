using MyMarket.Business.Domain;
using MyMarket.Business.Interfaces;
using MyMarket.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyMarket.UnitTests
{
    public class USDCurrencyServiceTests
    {
        private readonly ICurrencyService _currencyService;
        public USDCurrencyServiceTests()
        {
            _currencyService = new USDCurrencyService();
        }

        [Theory]
        [InlineData(120, Currency.GBP)]
        public void GetConvertedAmount_Test(double amount, Currency targetCurrency)
        {
            // Act
            double sut=_currencyService.GetConvertedAmount(amount, targetCurrency);


            // Assert
            Assert.True(sut > 0);
        }

        [Theory]
        [InlineData(120, Currency.GBP)]
        public void GetDenominations_Test(double amount, Currency targetCurrency)
        {
            // Act
            double sut = _currencyService.GetConvertedAmount(amount, targetCurrency);


            // Assert
            Assert.True(sut > 0);
        }
    }
}
