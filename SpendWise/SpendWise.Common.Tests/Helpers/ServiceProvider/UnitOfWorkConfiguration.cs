using Microsoft.Extensions.DependencyInjection;
using SpendWise.DAL.UnitOfWork;

namespace SpendWise.Common.Tests.Helpers
{
    public static class UnitOfWorkConfiguration
    {
        public static void ConfigureUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}