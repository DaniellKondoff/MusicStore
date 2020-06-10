namespace MusicStoreWeb.Services.Models.Albums
{
    public class AlbumsListingServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AmountOfSongs { get; set; }

        public decimal Price { get; set; }

        public string Artist { get; set; }
    }
}
