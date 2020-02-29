using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Models
{
    public class OS
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GameSystem> GameSystems { get; set; }
    }
}
