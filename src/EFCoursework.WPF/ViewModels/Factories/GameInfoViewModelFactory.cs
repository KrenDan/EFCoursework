using EFCoursework.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.ViewModels.Factories
{
    public class GameInfoViewModelFactory : IViewModelFactory<GameInfoViewModel>
    {
        private readonly IGameService _gameService;

        public GameInfoViewModelFactory(IGameService gameService)
        {
            _gameService = gameService;
        }

        public GameInfoViewModel CreateViewModel()
        {
            return new GameInfoViewModel(_gameService);
        }
    }
}
