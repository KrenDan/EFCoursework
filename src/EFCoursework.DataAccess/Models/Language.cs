using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool InterfaceSupported { get; set; }
        public bool FullAudioSupported { get; set; }
        public bool SubtitlesSupported { get; set; }
    }
}
