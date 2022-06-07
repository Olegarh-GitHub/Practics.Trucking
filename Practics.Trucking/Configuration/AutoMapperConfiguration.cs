using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practics.Trucking.Application.AutoMapping;
using Practics.Trucking.Infrastructure.AutoMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.Trucking.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper
            (
                typeof(EntityUpdateMappingProfile),
                typeof(InputMappingProfile)
            );
        }
    }
}
