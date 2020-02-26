using AutoMapper;
using EFCoursework.BusinessLogic.Infrastructure.Mapper;
using EFCoursework.WPF.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EFCoursework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IConfiguration _configuration;
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            _serviceProvider =
                PresentationConfiguration.ConfigureServices(new ServiceCollection(), _configuration)
                //.AddSingleton<ViewModelLocator>()
                .BuildServiceProvider();

            //var config = new MapperConfiguration(cfg => cfg.AddMaps(new[] { "EFCoursework.BusinessLogic" }));
            //config.CompileMappings();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
