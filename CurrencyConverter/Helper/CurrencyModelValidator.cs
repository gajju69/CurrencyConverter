using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Helper
{
    public static class CurrencyModelValidator
    {

        public static bool Validate(this CurrencyConvertWithString model)
        {
            if (model == null || model.Amount <= 0 || string.IsNullOrEmpty(model.InputCurrency) || string.IsNullOrEmpty(model.OutputCurrency))
                return false;
            return true;
        }

        public static bool Validate(this CurrencyConvertWithEnum model)
        {
            if (model == null || model.Amount <= 0)
                return false;
            return true;
        }
    }
}
