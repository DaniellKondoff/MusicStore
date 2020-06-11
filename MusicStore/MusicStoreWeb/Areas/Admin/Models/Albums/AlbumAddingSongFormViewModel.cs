using System.ComponentModel.DataAnnotations;

namespace MusicStoreWeb.Areas.Admin.Models.Albums
{
    public class AlbumAddingSongFormViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int SongId { get; set; }
    }
}
