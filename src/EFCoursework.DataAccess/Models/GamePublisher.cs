using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Models
{
    public class GamePublisher
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
