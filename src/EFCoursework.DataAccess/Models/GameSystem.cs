using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Models
{
    public class GameSystem
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int OSId { get; set; }
        public OS OS { get; set; }
    }
}
