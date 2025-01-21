using Microsoft.Extensions.DependencyInjection;
using SpendWise.DAL.Mappers;
using SpendWise.BLL.Mappers;

namespace SpendWise.Common.Tests.Helpers
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(MappingProfile),
                typeof(CategoryMappingProfile),
                typeof(TransactionMappingProfile),
                typeof(GroupMappingProfile),
                typeof(UserMappingProfile),
                typeof(InvitationMappingProfile));
        }
    }
}