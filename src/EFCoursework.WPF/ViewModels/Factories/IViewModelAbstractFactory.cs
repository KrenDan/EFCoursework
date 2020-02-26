using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.ViewModels.Factories
{
    public interface IViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }

    public enum ViewType
    {
        Home,
        Page
    }
}
