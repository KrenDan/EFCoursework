using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.BusinessLogic.DTO
{
    public class OSDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<GameDTO> Games { get; set; }
    }
}
