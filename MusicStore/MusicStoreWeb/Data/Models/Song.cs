﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MusicStoreWeb.Data.DataConstants;

namespace MusicStoreWeb.Data.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Required]
        [MinLength(SongTitleMinLenght)]
        [MaxLength(SongTitleMaxLenght)]
        public string Name { get; set; }

        public double Duration { get; set; }

        [Range(SongMinPrice, double.MaxValue)]
        public decimal Price { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public Ganre Ganre { get; set; }

        public List<SongAlbum> Albums { get; set; } = new List<SongAlbum>();

    }
}
