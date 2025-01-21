using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SpendWise.Common.Tests.Helpers
{
    public static class LoggingConfiguration
    {
        public static void ConfigureLogging(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole(); // Configure console logging
            });
        }
    }
}