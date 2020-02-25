using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Models
{
    public class GameGenre
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
