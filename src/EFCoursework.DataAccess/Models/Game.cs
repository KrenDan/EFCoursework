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
        public int ReviewPercentage { get; set; }
        public virtual ICollection<OS> SupportedSystems { get; set; }
        public virtual ICollection<Developer> Developers { get; set; }
        public virtual ICollection<Publisher> Publishers { get; set; }
        public virtual ICollection<Language> SupportedLanguages { get; set; }
        public string ClientIconUrl { get; set; }
        public string LogoUrl { get; set; }
        public string SteamUrl { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Image> Screenshots { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
