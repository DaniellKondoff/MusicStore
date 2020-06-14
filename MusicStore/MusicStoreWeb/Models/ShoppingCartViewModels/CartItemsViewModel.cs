using MusicStoreWeb.Services.Models.Albums;
using MusicStoreWeb.Services.Models.Songs;
using System.Collections.Generic;

namespace MusicStoreWeb.Models.ShoppingCartViewModels
{
    public class CartItemsViewModel
    {
        public IEnumerable<SongShoppingDetailsServiceModel> ShoppingSongs { get; set; }

        public IEnumerable<AlbumShoppingDetailsServiceModels> ShoppingAlbums { get; set; }
    }
}
