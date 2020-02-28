using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool IsReleased { get; set; }
        public int Discount { get; set; }
        public int ReviewCount { get; set; }
        public int ReviewScore { get; set; }
        public float ReviewPercentage { get; set; }
        public ICollection<GameSystem> SupportedSystems { get; set; }
        public ICollection<GameDeveloper> Developers { get; set; }
        public ICollection<GamePublisher> Publishers { get; set; }
        public ICollection<GameLanguage> SupportedLanguages { get; set; }
        public string ClientIconUrl { get; set; }
        public string LogoUrl { get; set; }
        public string SteamUrl { get; set; }
        public ICollection<GameGenre> Genres { get; set; }
        public ICollection<GameTag> Tags { get; set; }
        public ICollection<Image> Screenshots { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
