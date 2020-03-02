using EFCoursework.BusinessLogic.DTO;
using EFCoursework.BusinessLogic.Services;
using EFCoursework.WPF.Factories;
using EFCoursework.WPF.Infrastructure;
using EFCoursework.WPF.Interfaces;
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
using System.Windows.Input;

namespace EFCoursework.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IWindowFactory windowFactory, IGameService gameService,
            IParseService<IEnumerable<GameDTO>> parseService, GameInfoViewModel gameInfoViewModel)
        {
            _windowFactory = windowFactory;
            _gameService = gameService;
            _parseService = parseService;
            GameInfoViewModel = gameInfoViewModel;
        }

        private readonly IWindowFactory _windowFactory;
        private readonly IGameService _gameService;
        private readonly IParseService<IEnumerable<GameDTO>> _parseService;

        public GameInfoViewModel GameInfoViewModel { get; private set; }

        private ObservableCollection<GameDTO> _games;
        public ObservableCollection<GameDTO> Games
        {
            get => _games;
            set { Set(ref _games, value); }
        }

        private GameDTO _selectedGame;
        public GameDTO SelectedGame
        {
            get => _selectedGame;
            set
            {
                if (value == null)
                    return;
                Set(ref _selectedGame, value);
                GameInfoViewModel.SetGame(_selectedGame);
            }
        }

        #region commands
        private ICommand _loadGamesCommand;
        public ICommand LoadGamesCommand
        {
            get
            {
                if (_loadGamesCommand == null)
                {
                    _loadGamesCommand = new RelayCommand(async () =>
                    {
                        // load games from database
                        var games = await _gameService.GetAllGamesAsync();
                        Games = new ObservableCollection<GameDTO>(games);
                    });
                }
                return _loadGamesCommand;
            }
        }

        private ICommand _addGameOpenWindowCommand;
        public ICommand AddGameOpenWindowCommand
        {
            get
            {
                if (_addGameOpenWindowCommand == null)
                {
                    _addGameOpenWindowCommand = new RelayCommand(() =>
                    {
                        _windowFactory.CreateAddGameWindow(this);
                    });
                }
                return _addGameOpenWindowCommand;
            }
        }

        private ICommand _closeWindowCommand;
        public ICommand CloseWindowCommand
        {
            get
            {
                if (_closeWindowCommand == null)
                {
                    _closeWindowCommand = new RelayCommand<IClosable>(window =>
                    {
                        window.Close();
                    });
                }
                return _closeWindowCommand;
            }
        }

        private ICommand _addGameCommand;
        public ICommand AddGameByIdCommand 
        { 
            get
            {
                if (_addGameCommand == null)
                {
                    _addGameCommand = new RelayCommand<string>(async str =>
                    {
                        //parse id
                        int.TryParse(str, out int id);
                        if (id == 0) return;
                        //parse game and add to database
                        var parsedGames = await _parseService.ParseAsync(id);
                        await _gameService.InsertGamesAsync(parsedGames);
                    });
                }

                return _addGameCommand;
            }
        }

        private ICommand _searchGamesCommand;
        public ICommand SearchGamesCommand
        {
            get
            {
                if (_searchGamesCommand == null)
                {
                    _searchGamesCommand = new RelayCommand<string>(async str =>
                    {

                    });
                }
                return _searchGamesCommand;
            }
        }
        #endregion
    }
}
