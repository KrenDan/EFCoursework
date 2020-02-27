using AutoMapper;
using EFCoursework.BusinessLogic.Infrastructure;
using EFCoursework.BusinessLogic.Infrastructure.Mapper;
using EFCoursework.BusinessLogic.Services;
using EFCoursework.WPF.ViewModels;
using EFCoursework.WPF.ViewModels.Factories;
using EFCoursework.WPF.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EFCoursework.WPF.Infrastructure
{
    public static class PresentationConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            BusinessConfiguration.ConfigureServices(services, configuration);

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperProfile)));
            services.AddTransient<IGameService, GameService>();

            services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
            services.AddSingleton<IViewModelFactory<MainViewModel>, MainViewModelFactory>();
            services.AddSingleton<IViewModelFactory<GameInfoViewModel>, GameInfoViewModelFactory>();

            services.AddScoped<MainViewModel>();

            services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services;
        }
    }
}
