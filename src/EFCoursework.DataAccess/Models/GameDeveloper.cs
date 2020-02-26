using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Models
{
    public class GameDeveloper
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
    }
}
