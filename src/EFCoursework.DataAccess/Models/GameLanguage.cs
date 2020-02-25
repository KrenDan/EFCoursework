using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Models
{
    public class GameLanguage
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public bool InterfaceSupported { get; set; }
        public bool FullAudioSupported { get; set; }
        public bool SubtitlesSupported { get; set; }
    }
}
