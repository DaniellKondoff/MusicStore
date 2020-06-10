using System.Collections.Generic;

namespace MusicStoreWeb.Services.Models.Albums
{
    public class AlbumDetailsServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public IEnumerable<string> Songs { get; set; }
    }
}
