using CurrencyConverter.Helper;
using CurrencyConverter.Models;
using CurrencyConverter.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyConverter.Repositories
{
    /// <summary>
    /// Currency Service Class
    /// </summary>
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyConversionRepository _service;
        private const string ArgumentNullExceptionMessage = "Input was not in Correct Format";
        public CurrencyService(ICurrencyConversionRepository service)
        {
            this._service = service;
        }

        /// <summary>
        /// Converts the InputCurrency to OutputCurrency with amount
        /// </summary>
        /// <param name="currencyModel">Amount,inputcurrency string, output currency string</param>
        /// <returns>Converted currency amount</returns>
        public decimal Convert(CurrencyConvertWithString currencyModel)
        {
            //Validate input model
            if (!currencyModel.Validate())
                throw new ArgumentNullException(ArgumentNullExceptionMessage);
            //Check Both Equal
            if (currencyModel.InputCurrency.Equals(currencyModel.OutputCurrency,StringComparison.InvariantCultureIgnoreCase))
            {
                return currencyModel.Amount;
            }
            var listCurrencies = _service.GetAll();
            if (listCurrencies == null)
            {
                throw new ArgumentNullException(ArgumentNullExceptionMessage);
            }

            //Check inputcurrency exists in list 
            if (!listCurrencies.Exists(q =>  q.Name.Equals(currencyModel.InputCurrency,StringComparison.InvariantCultureIgnoreCase)))
                throw new ArgumentNullException(ArgumentNullExceptionMessage);
            //Check outputcurrency exists in list 
            if (!listCurrencies.Exists(q =>  q.Name.Equals(currencyModel.OutputCurrency, StringComparison.InvariantCultureIgnoreCase)))
                throw new ArgumentNullException(ArgumentNullExceptionMessage);

            //Logic to convert Any to any 
            var inputCurrencyDetail = listCurrencies.FirstOrDefault(q => q.Name.Equals(currencyModel.InputCurrency,StringComparison.InvariantCultureIgnoreCase));
            var singleRate = 1 / inputCurrencyDetail.RateFromUsd;
            var outputCurrencyDetail = listCurrencies.FirstOrDefault(q => q.Name.Equals(currencyModel.OutputCurrency,StringComparison.InvariantCultureIgnoreCase));
            singleRate = singleRate * outputCurrencyDetail.RateFromUsd;
            return decimal.Parse((singleRate * currencyModel.Amount).ToString(), System.Globalization.NumberStyles.Any);

        }

        /// <summary>
        /// Converts the InputCurrency to OutputCurrency with amount
        /// </summary>
        /// <param name="currencyModel">Amount,inputcurrency enum, output currency enum</param>
        /// <returns>Converted currency amount</returns>
        public decimal Convert(CurrencyConvertWithEnum currencyModel)
        {
            //Validate input model
            if (!currencyModel.Validate())
                throw new ArgumentNullException(ArgumentNullExceptionMessage);
            //Check Both Equal
            if (currencyModel.InputCurrency.ToString() == currencyModel.OutputCurrency.ToString())
            {
                return currencyModel.Amount;
            }
            var listCurrencies = _service.GetAll();
            if (listCurrencies == null)
            {
                throw new ArgumentNullException(ArgumentNullExceptionMessage);
            }

            //Check inputcurrency exists in list 
            if (!listCurrencies.Exists(q => q.Name.Equals(currencyModel.InputCurrency.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                throw new ArgumentNullException(ArgumentNullExceptionMessage);
            //Check outputcurrency exists in list
            if (!listCurrencies.Exists(q => q.Name.Equals(currencyModel.OutputCurrency.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                throw new ArgumentNullException(ArgumentNullExceptionMessage);

            //Logic to convert Any to any 
            var inputCurrencyDetail = listCurrencies.FirstOrDefault(q => q.Name.Equals(currencyModel.InputCurrency.ToString(),StringComparison.InvariantCultureIgnoreCase));
            var singleRate = 1 / inputCurrencyDetail.RateFromUsd;
            var outputCurrencyDetail = listCurrencies.FirstOrDefault(q => q.Name.Equals( currencyModel.OutputCurrency.ToString(),StringComparison.InvariantCultureIgnoreCase));
            singleRate = singleRate * outputCurrencyDetail.RateFromUsd;
            return decimal.Parse((singleRate * currencyModel.Amount).ToString(), System.Globalization.NumberStyles.Any);
        }
    }
}
