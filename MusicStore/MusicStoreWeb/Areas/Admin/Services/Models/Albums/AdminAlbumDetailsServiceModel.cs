using System.Collections.Generic;

namespace MusicStoreWeb.Areas.Admin.Services.Models.Albums
{
    public class AdminAlbumDetailsServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public IEnumerable<string> Songs { get; set; }
    }
}
