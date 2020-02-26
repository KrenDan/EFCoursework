using EFCoursework.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.ViewModels.Factories
{
    public class MainViewModelFactory : IViewModelFactory<MainViewModel>
    {
        private readonly IGameService _gameService;

        public MainViewModelFactory(IGameService gameService)
        {
            _gameService = gameService;
        }

        public MainViewModel CreateViewModel()
        {
            return new MainViewModel(_gameService);
        }
    }
}
