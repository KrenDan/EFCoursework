using EFCoursework.WPF.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.Infrastructure
{
    public class ViewModelLocator
    {
        private IServiceProvider _serviceProvider;

        public ViewModelLocator()
        {

        }

        public ViewModelLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public GameViewModel Game => _serviceProvider.GetRequiredService<GameViewModel>();
    }
}
