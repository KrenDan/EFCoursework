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
            get => _name;
            set { Set(ref _name, value); }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set { Set(ref _description, value); }
        }

        private string _logoUrl;
        public string LogoUrl
        {
            get => _logoUrl;
            set { Set(ref _logoUrl, value); }
        }

        private decimal _price;
        public decimal Price 
        { 
            get => _price; 
            set { Set(ref _price, value); } 
        }

        private DateTime? _releaseDate;
        public DateTime? ReleaseDate
        {
            get => _releaseDate;
            set { Set(ref _releaseDate, value); }
        }

        private int _reviewCount;
        public int ReviewCount
        {
            get => _reviewCount;
            set { Set(ref _reviewCount, value); }
        }

        private float _reviewPercentage;
        public float ReviewPercentage
        {
            get => _reviewPercentage;
            set { Set(ref _reviewPercentage, value); }
        }

        private string _steamUrl;
        public string SteamUrl
        {
            get => _steamUrl;
            set { Set(ref _steamUrl, value); }
        }

        public void SetGame(GameDTO game)
        {
            Name = game.Name;
            Description = game.Description;
            LogoUrl = game.LogoUrl;
            Price = game.Price;
            ReleaseDate = game.ReleaseDate;
            ReviewCount = game.ReviewCount;
            ReviewPercentage = game.ReviewPercentage;
            SteamUrl = game.SteamUrl;
        }
    }
}
