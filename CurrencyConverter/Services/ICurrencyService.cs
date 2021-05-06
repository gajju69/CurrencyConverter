using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Repositories
{
    /// <summary> 
    /// Interface ICurrencyService
    /// </summary>
    interface ICurrencyService
    {
        /// <summary>
        /// Converts the InputCurrency to OutputCurrency with amount
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <returns>Converted currency amount</returns>
        decimal Convert(CurrencyConvertWithString model);

        /// <summary>
        /// Converts the InputCurrency to OutputCurrency with amount
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <returns>Converted currency amount</returns>
        decimal Convert(CurrencyConvertWithEnum model);
    }
}
