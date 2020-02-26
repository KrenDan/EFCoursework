using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Models
{
    public class GamePublisher
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
