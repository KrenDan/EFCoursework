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
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IGameService gameService)
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

        public int GameCount => _games.Count;

        private RelayCommand _loadCommand;
        public RelayCommand LoadGamesCommand
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
