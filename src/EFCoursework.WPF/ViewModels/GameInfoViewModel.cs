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

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { Set(ref _description, value); }
        }

        private string _logoUrl;
        public string LogoUrl
        {
            get { return _logoUrl; }
            set { Set(ref _logoUrl, value); }
        }

        public void SetGame(GameDTO game)
        {
            Name = game.Name;
            Description = game.Description;
            LogoUrl = game.LogoUrl;
        }
    }
}
