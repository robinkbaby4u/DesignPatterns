using MyMarket.Business.Domain;
using MyMarket.Business.Interfaces;
using MyMarket.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMarket.Business.Abstract
{
    public abstract class CurrencyFactory
    {
        public abstract ICurrencyService Create();
    }
}
