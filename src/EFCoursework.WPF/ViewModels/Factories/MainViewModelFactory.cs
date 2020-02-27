using EFCoursework.BusinessLogic.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.ViewModels.Factories
{
    public class MainViewModelFactory : IViewModelFactory<MainViewModel>
    {
        private readonly IGameService _gameService;
        private readonly GameInfoViewModel _gameInfoViewModel;

        public MainViewModelFactory(IGameService gameService, GameInfoViewModel gameInfoViewModel)
        {
            _gameService = gameService;
            _gameInfoViewModel = gameInfoViewModel;
        }

        public MainViewModel CreateViewModel()
        {
            return new MainViewModel(_gameService, _gameInfoViewModel);
        }
    }
}
