using CommonServiceLocator;
using EFCoursework.BusinessLogic.Services;
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
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IGameService, GameService>();
            SimpleIoc.Default.Register<GameViewModel>();
        }

        public GameViewModel Game => ServiceLocator.Current.GetInstance<GameViewModel>();
    }
}
