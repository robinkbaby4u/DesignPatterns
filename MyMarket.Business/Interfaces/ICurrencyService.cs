using MyMarket.Business.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMarket.Business.Interfaces
{
    public interface ICurrencyService
    {
        double GetConvertedAmount(double amountToConvert, Currency targetCurrency);

        ForexRate GetForexRatesForCurrency();

        StringBuilder GetDenominations(double amount);
    }
}
