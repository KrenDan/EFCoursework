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
        public float ReviewPercentage { get; set; }
        public ICollection<OSDTO> SupportedSystems { get; set; }
        public ICollection<DeveloperDTO> Developers { get; set; }
        public ICollection<PublisherDTO> Publishers { get; set; }
        public ICollection<LanguageDTO> InterfaceSupportedLanguages { get; set; }
        public ICollection<LanguageDTO> FullAudioSupportedLanguages { get; set; }
        public ICollection<LanguageDTO> SubtitlesSupportedLanguages { get; set; }
        public string ClientIconUrl { get; set; }
        public string LogoUrl { get; set; }
        public string SteamUrl { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<TagDTO> Tags { get; set; }
        public ICollection<ImageDTO> Screenshots { get; set; }
        public ICollection<VideoDTO> Videos { get; set; }
    }
}
