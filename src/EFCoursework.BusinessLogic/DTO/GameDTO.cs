using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.BusinessLogic.DTO
{
    public class GameDTO
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
        public int ReviewPercentage { get; set; }
        public virtual ICollection<GameSystemDTO> SupportedSystems { get; set; }
        public virtual ICollection<GameDeveloperDTO> Developers { get; set; }
        public virtual ICollection<GamePublisherDTO> Publishers { get; set; }
        public virtual ICollection<GameLanguageDTO> SupportedLanguages { get; set; }
        public string ClientIconUrl { get; set; }
        public string LogoUrl { get; set; }
        public string SteamUrl { get; set; }
        public virtual ICollection<GameGenreDTO> Genres { get; set; }
        public virtual ICollection<GameTagDTO> Tags { get; set; }
        public virtual ICollection<ImageDTO> Screenshots { get; set; }
        public virtual ICollection<VideoDTO> Videos { get; set; }
    }
}
