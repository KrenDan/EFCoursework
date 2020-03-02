using EFCoursework.WPF.Infrastructure;
using EFCoursework.WPF.ViewModels;
using EFCoursework.WPF.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EFCoursework.WPF.Factories
{
    public class WindowFactory : IWindowFactory
    {
        public void CreateAddGameWindow(object ownerWindow, MainViewModel viewModel)
        {
            var window = new AddGameWindow()
            {
                DataContext = viewModel,
                Owner = ownerWindow as Window
            };
            window.Show();
        }
    }
}
