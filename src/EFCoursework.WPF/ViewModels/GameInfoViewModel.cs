using EFCoursework.BusinessLogic.DTO;
using EFCoursework.BusinessLogic.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.ViewModels
{
    public class GameInfoViewModel : ViewModelBase
    {
        public GameInfoViewModel(IGameService gameService)
        {
            _gameService = gameService;
        }

        private readonly IGameService _gameService;

        private GameDTO _selectedGame;
        public GameDTO SelectedGame 
        {
            get { 
                return _selectedGame; 
            }
            set { Set(ref _selectedGame, value); }
        }
    }
}
