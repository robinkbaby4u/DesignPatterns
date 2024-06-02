using MyMarket.Business.Domain;
using MyMarket.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMarket.Business.Services
{
    public class EURCurrencyService : ICurrencyService
    {
        private List<int> currencyList;
        private List<int> coinList;
        private Currency baseCurrency;

        public double GetConvertedAmount(double amountToConvert, Currency targetCurrency)
        {
            baseCurrency = Currency.GBP;
            ForexRate _forexRatesForEUR = GetForexRatesForCurrency();

            switch (targetCurrency)
            {
                case Currency.EUR:
                    return Math.Round(amountToConvert,2);

                case Currency.GBP:
                    return Math.Round(amountToConvert * _forexRatesForEUR.GBP,2);

                case Currency.USD:
                    return Math.Round(amountToConvert * _forexRatesForEUR.USD,2);

                default: return 0;
            }
        }

        public StringBuilder GetDenominations(double amount)
        {
            StringBuilder denominations = new StringBuilder();

            currencyList = new int[]
            {
                5,10,20,50,100,200
            }
            .OrderByDescending(x => x).ToList();

            coinList = new int[]
            {
                1,2,5,10,20,50,100,200
            }
            .OrderByDescending(x => x).ToList();

            denominations.Append("<ul>");
            denominations.Append("<li><b>Notes</b></li>");
            double aftervalue = amount;

            foreach (int currency in currencyList)
            {
                int currencyCount = (int)(aftervalue / currency);
                aftervalue = aftervalue - currencyCount * currency;

                if (currencyCount > 0)
                {
                    string denomination = $"€ {currency}s:  " + currencyCount;
                    denominations.Append("<li>" + denomination + "</li>");
                }
            }

            aftervalue = aftervalue * 100;
            denominations.Append("<li><b>coins</b></li>");

            foreach (int coin in coinList)
            {
                int coinCount = (int)(aftervalue / coin);
                aftervalue = aftervalue - coinCount * coin;

                if (coinCount > 0)
                {
                    if (coin > 50)
                    {
                        string denomination = $"€ {coin / 100}s:  " + coinCount;
                        denominations.Append("<li>" + denomination + "</li>");
                    }
                    else
                    {
                        string denomination = $"cent {coin}s:  " + coinCount;
                        denominations.Append("<li>" + denomination + "</li>");
                    }
                }
            }

            denominations.Append("</ul>");
            return denominations;
        }

        public ForexRate GetForexRatesForCurrency()
        {
            return new ForexRate()
            {
                GBP = 1.10,
                USD = 0.85
            };
        }
    }
}
