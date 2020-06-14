﻿using MusicStoreWeb.Areas.Admin.Services.Models.Artists;
using MusicStoreWeb.Services;
using System;
using System.Collections.Generic;

namespace MusicStoreWeb.Areas.Admin.Models.Artists
{
    public class ArtistListingViewModel
    {
        public IEnumerable<AdminArtistListingServiceModel> AllArtists { get; set; }

        public int TotalArtists { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalArtists / ServiceConstants.AdminArtistsListingPageSize);

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
