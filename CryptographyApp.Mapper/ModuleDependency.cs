using CryptographyApp.Mapper.Maps;
using Microsoft.Extensions.DependencyInjection;

namespace CryptographyApp.Mapper
{
    public static class ModuleDependency
    {

        public static IServiceCollection AddCryptographyMapper(this IServiceCollection services)
        {
            services.AddSingleton<ICryptographyMapper, CryptographyMapper>();

            return services;
        }
    }
}