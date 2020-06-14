using System.ComponentModel.DataAnnotations;
using static MusicStoreWeb.Data.DataConstants;


namespace MusicStoreWeb.Areas.Admin.Models.Artists
{
    public class ArtistFormViewModel
    {
        [Required]
        [MinLength(ArtistNameMinLenght)]
        [MaxLength(ArtistNameMaxLenght)]
        public string Name { get; set; }
    }
}
