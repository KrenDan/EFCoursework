using EFCoursework.BusinessLogic.DTO;
using EFCoursework.BusinessLogic.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace EFCoursework.WPF.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        public GameViewModel(IGameService gameService)
        {
            _gameService = gameService;
        }

        private readonly IGameService _gameService;

        private ObservableCollection<GameDTO> _games;
        public ObservableCollection<GameDTO> Games
        {
            get { return _games; }
            set { Set(ref _games, value); }
        }

        private RelayCommand _loadCommand;
        public RelayCommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                {
                    _loadCommand = new RelayCommand(async () =>
                    {
                        var games = await _gameService.GetAllGamesAsync();
                        Games = new ObservableCollection<GameDTO>(games);
                    });
                }
                return _loadCommand;
            }
        }
    }
}
