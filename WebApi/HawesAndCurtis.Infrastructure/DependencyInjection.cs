using Microsoft.Extensions.DependencyInjection;
using HawesAndCurtis.Core.Logging;
using HawesAndCurtis.Core.Repository;
using HawesAndCurtis.Core.Repository.Base;
using HawesAndCurtis.Infrastructure.Logging;
using HawesAndCurtis.Infrastructure.Repository;
using HawesAndCurtis.Infrastructure.Repository.Base;

namespace HawesAndCurtis.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // repositories
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductRecommendationRepository, ProductRecommendationRepository>();
            services.AddScoped<IProductSpecificationAssociationRepository, ProductSpecificationAssociationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRecommendationRepository, ProductRecommendationRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IHawesAndCurtisLogger<>), typeof(HawesAndCurtisLogger<>));
            return services;
        }
    }
}
