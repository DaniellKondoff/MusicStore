using MusicStoreWeb.Services.Models.Albums;
using MusicStoreWeb.Services.Models.Songs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStoreWeb.Services.Contracts
{
    public interface IShoppingService
    {
        Task CreateOrderAsync(string userId, IEnumerable<SongShoppingDetailsServiceModel> itemsWithDetails, IEnumerable<AlbumShoppingDetailsServiceModels> itemsAlbumsWithDetails);
    }
}
