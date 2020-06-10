﻿using MusicStoreWeb.Services.Models.Albums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStoreWeb.Services.Contracts
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumsListingServiceModel>> ListAllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<AlbumDetailsServiceModel> DetailsAsync(int id);

        Task<IEnumerable<AlbumsListingServiceModel>> FindAsync(string searchText);

        Task<IEnumerable<AlbumShoppingDetailsServiceModels>> AlbumsShoppingDetails(IEnumerable<int> itemAlbumsIds);
    }
}
