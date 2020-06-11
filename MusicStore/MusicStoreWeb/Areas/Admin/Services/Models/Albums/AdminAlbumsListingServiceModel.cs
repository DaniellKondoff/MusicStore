namespace MusicStoreWeb.Areas.Admin.Services.Models.Albums
{
    public class AdminAlbumsListingServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AmountOfSongs { get; set; }

        public decimal Price { get; set; }

        public string Artist { get; set; }
    }
}
