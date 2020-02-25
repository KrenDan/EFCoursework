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
        public DateTime ReleaseDate { get; set; }
    }
}
