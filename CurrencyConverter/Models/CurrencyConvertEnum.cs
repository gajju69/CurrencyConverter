namespace CurrencyConverter.Models
{
    public class CurrencyConvertWithEnum
    {
        public decimal Amount { get; set; }

        public Currency InputCurrency { get; set; }

        public Currency OutputCurrency { get; set; }

    }

}
