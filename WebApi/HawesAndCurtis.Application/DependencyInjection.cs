using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using HawesAndCurtis.Application.Common.Mappings;
using HawesAndCurtis.Application.Handlers;

namespace HawesAndCurtis.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(typeof(CreateUserCommandHandler).GetTypeInfo().Assembly);
            return services;
        }
    }
}
