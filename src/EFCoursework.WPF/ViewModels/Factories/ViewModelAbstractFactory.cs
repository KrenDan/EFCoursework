using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.ViewModels.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly MainViewModelFactory _mainViewModelFactory;
        private readonly GameInfoViewModelFactory _testViewModelFactory;

        public ViewModelAbstractFactory(MainViewModelFactory mainViewModelFactory, GameInfoViewModelFactory testViewModelFactory)
        {
            _mainViewModelFactory = mainViewModelFactory;
            _testViewModelFactory = testViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Main:
                    return _mainViewModelFactory.CreateViewModel();
                case ViewType.GameInfo:
                    return _testViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("ViewType doesn't have a ViewModel.", nameof(viewType));
            }
        }
    }
}
