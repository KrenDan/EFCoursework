using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EFCoursework.BusinessLogic.Services;
using EFCoursework.WPF.Infrastructure;
using EFCoursework.BusinessLogic.DTO;

namespace EFCoursework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGameService _gameService;

        public IServiceProvider ServiceProvider { get; }
        public List<GameDTO> Games { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();

            ServiceProvider = 
                PresentationConfiguration.ConfigureServices(new ServiceCollection(), configuration)
                .BuildServiceProvider();

            _gameService = ServiceProvider.GetRequiredService<IGameService>();
        }

        private async void Window_LoadedAsync(object sender, RoutedEventArgs e)
        {
            gamesDataGrid.ItemsSource = await _gameService.GetAllGamesAsync();
        }
    }
}
