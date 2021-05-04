using Microsoft.Extensions.DependencyInjection;
using HawesAndCurtis.Application.Common.Identity;
using HawesAndCurtis.Api.Common.Identity;

namespace HawesAndCurtis.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUser, CurrentUser>();
            return services;
        }
    }
}
