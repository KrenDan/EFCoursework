﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GameGenre> GameGenres { get; set; }
    }
}
