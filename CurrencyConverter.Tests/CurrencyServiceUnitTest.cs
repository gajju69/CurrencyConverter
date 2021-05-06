using CurrencyConverter.Models;
using CurrencyConverter.Repositories;
using System;
using Xunit;

namespace CurrencyConverter.Tests
{

    public class CurrencyServiceUnitTest
    {
        private readonly ICurrencyConversionRepository _service;
        public CurrencyServiceUnitTest()
        {
            this._service = new CurrencyConversionRepository();
        }

        //String Model Input null
        [Fact]
        public void Should_Check_StringCurrencyInput_ShoulNotBeNullOrEmpty_BTCToUSD_WithInValidInput()
        {
            CurrencyService function = new CurrencyService(_service);
            CurrencyConvertWithString currencyConvert = null;
            Action act = () => function.Convert(currencyConvert);
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Input was not in Correct Format",  exception.ParamName);
        }

        //String Amount tests
        [Fact]
        public void Should_Check_AmountNotZero_StringCurrencyInput_CADToUSD_WithInValidInput()
        {
            CurrencyService function = new CurrencyService(_service);
            CurrencyConvertWithString currencyConvert = new CurrencyConvertWithString() { Amount = 0, InputCurrency = "CAD", OutputCurrency = "USD" };
            Action act = () => function.Convert(currencyConvert);
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Input was not in Correct Format",  exception.ParamName);

        }

        [Fact]
        public void Should_Check_Amount_NotLessThanZero_StringCurrencyInput_CADToBTC_WithValidInput()
        {
            CurrencyService function = new CurrencyService(_service);
            CurrencyConvertWithString currencyConvert = new CurrencyConvertWithString() { Amount = 25.5m, InputCurrency = "CAD", OutputCurrency = "BTC" };
            var response = function.Convert(currencyConvert);
            Assert.True(response > 0);
        }

        [Fact]
        public void Should_Check_Amount_NotLessThanZero_StringCurrencyInput_CADToBTC_WithInValidInput()
        {
            CurrencyService function = new CurrencyService(_service);
            CurrencyConvertWithString currencyConvert = new CurrencyConvertWithString() { Amount = -6, InputCurrency = "CAD", OutputCurrency = "BTC" };
            Action act = () => function.Convert(currencyConvert);
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Input was not in Correct Format",  exception.ParamName);
        }


        //String - Currency empty
        [Fact]
        public void Should_Check_InputCurrencyOutputCurrency_ShouldNotEmptyOrNull_StringCurrencyInput_CADToBTC_WithInValidInput()
        {
            CurrencyService function = new CurrencyService(_service);
            CurrencyConvertWithString currencyConvert = new CurrencyConvertWithString() { Amount = 23, InputCurrency = string.Empty, OutputCurrency = "BTC" };
            Action act = () => function.Convert(currencyConvert);
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Input was not in Correct Format",  exception.ParamName);
        }

        [Fact]
        public void Should_Check_InputCurrencyOrOutputCurrency_ShouldBeCorrect_StringCurrencyInput_CADToBTC_WithInValidInput()
        {
            CurrencyService function = new CurrencyService(_service);
            CurrencyConvertWithString currencyConvert = new CurrencyConvertWithString() { Amount = 23, InputCurrency = "CDA", OutputCurrency = "BTC" };
            Action act = () => function.Convert(currencyConvert);
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Input was not in Correct Format",  exception.ParamName);
        }

        [Fact]
        public void Should_Check_InputCurrencyOrOutputCurrency_ShouldBeCorrect_StringCurrencyInput_CADToBTC_WithValidInput()
        {
            CurrencyService function = new CurrencyService(_service);
            CurrencyConvertWithString currencyConvert = new CurrencyConvertWithString() { Amount = 23, InputCurrency = "CAD", OutputCurrency = "BTC" };
            var response = function.Convert(currencyConvert);
            Assert.True(response > 0);
        }

        //Enum model Input null

        [Fact]
        public void Should_Check_EnumCurrencyInput_ShoulNotBeNullOrEmpty_CADToUSD_WithInValidInput()
        {
            CurrencyService function = new CurrencyService(_service);
            CurrencyConvertWithEnum currencyConvert = null;
            Action act = () => function.Convert(currencyConvert);
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Input was not in Correct Format", exception.ParamName);
        }

        //Enum Amount tests
        [Fact]
        public void Should_Check_Amount_NotLessThanZero_EnumCurrencyInput_CADToUSD_WithInValidInput()
        {
            CurrencyService function = new CurrencyService(_service);
            CurrencyConvertWithEnum currencyConvert = new CurrencyConvertWithEnum() { Amount = -1, InputCurrency = Currency.CAD, OutputCurrency = Currency.USD };
            Action act = () => function.Convert(currencyConvert);
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Input was not in Correct Format",  exception.ParamName);
        }

        [Fact]
        public void Should_Check_Amount_NotLessThanZero_EnumCurrencyInput_CADToUSD_WithValidInput()
        {
            CurrencyService function = new CurrencyService(_service);
            CurrencyConvertWithEnum currencyConvert = new CurrencyConvertWithEnum() { Amount = 200, InputCurrency = Currency.CAD, OutputCurrency = Currency.USD };
            var response = function.Convert(currencyConvert);
            Assert.True(response > 0);
        }

        [Fact]
        public void Should_Check_Amount_ShouldNotZero_EnumCurrencyInput_CADToBTC_WithInValidInput()
        {
            CurrencyService function = new CurrencyService(_service);
            CurrencyConvertWithEnum currencyConvert = new CurrencyConvertWithEnum() { Amount = 0, InputCurrency = Currency.CAD, OutputCurrency = Currency.BTC };
            Action act = () => function.Convert(currencyConvert);
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Input was not in Correct Format",  exception.ParamName);
        }

    }
}
