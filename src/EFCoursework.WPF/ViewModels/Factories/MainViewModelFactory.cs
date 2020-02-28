using EFCoursework.BusinessLogic.DTO;
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
        private readonly IParseService<IEnumerable<GameDTO>> _parseService;
        private readonly GameInfoViewModel _gameInfoViewModel;

        public MainViewModelFactory(IGameService gameService, IParseService<IEnumerable<GameDTO>> parseService, GameInfoViewModel gameInfoViewModel)
        {
            _gameService = gameService;
            _parseService = parseService;
            _gameInfoViewModel = gameInfoViewModel;
        }

        public MainViewModel CreateViewModel()
        {
            return new MainViewModel(_gameService, _parseService, _gameInfoViewModel);
        }
    }
}
