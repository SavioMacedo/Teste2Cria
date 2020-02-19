using Business.Interfaces;
using Business.Logics;
using Infra.Context;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInjections(this ServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IWordLogics, WordLogics>();

            return services;
        }
    }
}
