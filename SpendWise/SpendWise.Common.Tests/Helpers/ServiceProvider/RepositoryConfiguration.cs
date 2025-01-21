using Microsoft.Extensions.DependencyInjection;
using SpendWise.DAL.Repositories;

namespace SpendWise.Common.Tests.Helpers
{
    public static class RepositoryConfiguration
    {
        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}