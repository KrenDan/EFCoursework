using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.BusinessLogic.DTO
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GameDTO> Games { get; set; }
    }
}
