using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.ViewModels.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly MainViewModelFactory _mainViewModelFactory;
        private readonly TestViewModelFactory _testViewModelFactory;

        public ViewModelAbstractFactory(MainViewModelFactory mainViewModelFactory, TestViewModelFactory testViewModelFactory)
        {
            _mainViewModelFactory = mainViewModelFactory;
            _testViewModelFactory = testViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _mainViewModelFactory.CreateViewModel();
                case ViewType.Page:
                    return _testViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("ViewType doesn't have a ViewModel.", nameof(viewType));
            }
        }
    }
}
