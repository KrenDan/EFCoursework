using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.BusinessLogic.DTO
{
    public class LanguageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GameDTO> Games { get; set; }
    }

    class LanguageDTOEqualityComparer : IEqualityComparer<LanguageDTO>
    {
        public bool Equals(LanguageDTO l1, LanguageDTO l2)
        {
            return l1.Name == l2.Name;
        }

        public int GetHashCode(LanguageDTO obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
