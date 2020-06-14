using MusicStoreWeb.Areas.Admin.Services.Models.Songs;
using MusicStoreWeb.Services;
using System;
using System.Collections.Generic;

namespace MusicStoreWeb.Areas.Admin.Models.Songs
{
    public class SongListingViewModel
    {
        public IEnumerable<AdminSongListingServiceModel> AllSongs { get; set; }

        public int TotalSongs { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalSongs / ServiceConstants.AdminSongListingPageSize);

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
