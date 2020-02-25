using EFCoursework.BusinessLogic.Infrastructure;
using EFCoursework.BusinessLogic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.Infrastructure
{
    public static class PresentationConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            BusinessConfiguration.ConfigureServices(services, configuration);

            services.AddTransient<IGameService, GameService>();

            return services;
        }
    }
}
