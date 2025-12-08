using AsteriskReport.ConsoleApp.DI;
using AsteriskReport.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsteriskReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var provider = DefaultDependencyModule.Configure(configuration);
            var asteriskReportGenerator = provider.GetRequiredService<AsteriskReportGenerator>();

            asteriskReportGenerator.Generate();
        }
    }
}
