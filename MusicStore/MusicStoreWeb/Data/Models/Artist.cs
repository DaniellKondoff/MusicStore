﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MusicStoreWeb.Data.DataConstants;

namespace MusicStoreWeb.Data.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ArtistNameMinLenght)]
        [MaxLength(ArtistNameMaxLenght)]
        public string Name { get; set; }

        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();

        public ICollection<Album> Albums { get; set; } = new HashSet<Album>();
    }
}
