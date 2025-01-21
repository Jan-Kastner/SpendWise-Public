using Microsoft.Extensions.DependencyInjection;

namespace SpendWise.Common.Tests.Helpers
{
    public static class TestServiceProvider
    {
        /// <summary>
        /// Creates and configures an <see cref="IServiceProvider"/> for use in unit tests.
        /// </summary>
        /// <returns>
        /// An <see cref="IServiceProvider"/> configured with the necessary services for testing.
        /// </returns>
        public static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            DatabaseConfiguration.ConfigureDatabase(services);
            AutoMapperConfiguration.ConfigureAutoMapper(services);
            RepositoryConfiguration.ConfigureRepositories(services);
            UnitOfWorkConfiguration.ConfigureUnitOfWork(services);
            LoggingConfiguration.ConfigureLogging(services);
            ServiceConfiguration.ConfigureServices(services);

            return services.BuildServiceProvider();
        }
    }
}