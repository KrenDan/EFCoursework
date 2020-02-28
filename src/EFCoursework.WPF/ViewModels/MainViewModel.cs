using EFCoursework.BusinessLogic.DTO;
using EFCoursework.BusinessLogic.Services;
using EFCoursework.WPF.ViewModels.Factories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Data;

namespace EFCoursework.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IGameService gameService, IParseService<IEnumerable<GameDTO>> parseService, GameInfoViewModel gameInfoViewModel)
        {
            _gameService = gameService;
            _parseService = parseService;
            GameInfoViewModel = gameInfoViewModel;
        }

        private readonly IGameService _gameService;
        private readonly IParseService<IEnumerable<GameDTO>> _parseService;

        public GameInfoViewModel GameInfoViewModel { get; private set; }

        private ObservableCollection<GameDTO> _games;
        public ObservableCollection<GameDTO> Games
        {
            get { return _games; }
            set { Set(ref _games, value); }
        }

        #region commands
        private RelayCommand<object> _chooseGameCommand;
        public RelayCommand<object> ChooseGameCommand
        {
            get
            {
                if (_chooseGameCommand == null)
                {
                    _chooseGameCommand = new RelayCommand<object>((obj) =>
                    {
                        GameInfoViewModel.SelectedGame = obj as GameDTO;
                    });
                }
                return _chooseGameCommand;
            }
        }

        private RelayCommand _loadGamesCommand;
        public RelayCommand LoadGamesCommand
        {
            get
            {
                if (_loadGamesCommand == null)
                {
                    _loadGamesCommand = new RelayCommand(async () =>
                    {
                        // parse games to database
                        var parsedGames = await _parseService.ParseAsync();
                        await _gameService.InsertGamesAsync(parsedGames);

                        // load games from database
                        var games = await _gameService.GetAllGamesAsync();
                        Games = new ObservableCollection<GameDTO>(games);
                    });
                }
                return _loadGamesCommand;
            }
        }
        #endregion
    }
}
