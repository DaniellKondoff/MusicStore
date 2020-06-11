using MusicStoreWeb.Data.Models;

namespace MusicStoreWeb.Areas.Admin.Services.Models.Songs
{
    public class AdminSongDetailsServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Duration { get; set; }

        public decimal Price { get; set; }

        public string Artist { get; set; }

        public Ganre Ganre { get; set; }
    }
}
