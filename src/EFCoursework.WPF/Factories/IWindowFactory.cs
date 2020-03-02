using EFCoursework.WPF.Infrastructure;
using EFCoursework.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.Factories
{
    public interface IWindowFactory
    {
        void CreateAddGameWindow(MainViewModel viewModel);
    }
}
