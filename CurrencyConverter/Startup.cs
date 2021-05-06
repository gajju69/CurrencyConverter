using CurrencyConverter.Repositories;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(CurrencyConverter.Startup))]
namespace CurrencyConverter
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ICurrencyConversionRepository>((s) =>
            {
                return new CurrencyConversionRepository();
            });
        }
    }

}
