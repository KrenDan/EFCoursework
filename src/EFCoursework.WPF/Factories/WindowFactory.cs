using EFCoursework.WPF.Infrastructure;
using EFCoursework.WPF.ViewModels;
using EFCoursework.WPF.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.Factories
{
    public class WindowFactory : IWindowFactory
    {
        public void CreateAddGameWindow(MainViewModel viewModel)
        {
            var window = new AddGameWindow()
            {
                DataContext = viewModel
            };
            window.Show();
        }
    }
}
