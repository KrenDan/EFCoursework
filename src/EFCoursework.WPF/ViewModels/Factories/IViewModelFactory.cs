using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.ViewModels.Factories
{
    public interface IViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
