using AsteriskReport.Contracts.Config;
using AsteriskReport.Logic.EventConverters;
using AsteriskReport.Logic.Graph;
using AsteriskReport.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AsteriskReport.Logic.Parsers;
using AsteriskReport.Contracts.Interfaces.EventConverters;
using AsteriskReport.Contracts.Interfaces.Parsers;
using AsteriskReport.Contracts.Interfaces.Graph;
using AsteriskReport.Logic.Calls;
using AsteriskReport.Contracts.Interfaces.Calls;

namespace AsteriskReport.ConsoleApp.DI
{
    public static class DefaultDependencyModule
    {
        public static IServiceProvider Configure(IConfigurationRoot configuration)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(configuration.GetRequiredSection("AppSettings").GetRequiredSection("BarGraphConfig").Get<BarGraphConfig>());
            services.AddSingleton<ICallLogReader, CallLogReader>();
            services.AddSingleton<ITimestampParser, TimestampParser>();
            services.AddSingleton<IEventTypeParser, EventTypeParser>();
            services.AddSingleton<ICallEventConverter, SuccessfulCallEventConverter>();
            services.AddSingleton<ICallEventConverter, AbandonedCallEventConverter>();
            services.AddSingleton<ICallEventConverter, NoAnswerCallEventConverter>();
            services.AddSingleton<ICallEventAnalyzer, CallEventAnalyzer>();

            services.AddSingleton<IQueueEventParser, QueueEventParser>();
            services.AddSingleton<IBarCreator, BarCreator>();
            services.AddSingleton<IBarGraphFactory, BarGraphFactory>();
            services.AddSingleton<IReportExporter, ReportExporter>();
            services.AddSingleton<AsteriskReportGenerator>();

            return services.BuildServiceProvider();
        }
    }
}
