using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
