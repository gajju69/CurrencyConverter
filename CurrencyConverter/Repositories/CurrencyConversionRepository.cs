using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Repositories
{
    public class CurrencyConversionRepository : ICurrencyConversionRepository
    {
        public List<CurrencyConversion> GetAll()
        {
            // Pretend this makes actual http calls
            return new List<CurrencyConversion>(new[]
            {
                new CurrencyConversion
                {
                    Name = "USD",
                    RateFromUsd = 1.00m
                },
                new CurrencyConversion
                {
                    Name = "CAD",
                    RateFromUsd = 1.23m
                },
                new CurrencyConversion
                {
                    Name = "BTC",
                    RateFromUsd = 0.000018m
                }
            });
        }
    }
}