using AutoMapper;
using EFCoursework.BusinessLogic.DTO;
using EFCoursework.BusinessLogic.Infrastructure;
using EFCoursework.BusinessLogic.Infrastructure.Mapper;
using EFCoursework.BusinessLogic.Services;
using EFCoursework.WPF.Factories;
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
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            BusinessConfiguration.ConfigureServices(services, configuration);

            services.AddSingleton<IWindowFactory, WindowFactory>();
            services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
            services.AddSingleton<IViewModelFactory<MainViewModel>, MainViewModelFactory>();
            services.AddSingleton<IViewModelFactory<GameInfoViewModel>, GameInfoViewModelFactory>();

            services.AddScoped<GameInfoViewModel>();
            services.AddScoped(s => s.GetRequiredService<IViewModelFactory<MainViewModel>>().CreateViewModel());

            services.AddScoped(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
        }
    }
}
