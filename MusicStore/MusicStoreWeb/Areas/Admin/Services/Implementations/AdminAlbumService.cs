using MusicStoreWeb.Areas.Admin.Services.Contracts;
using MusicStoreWeb.Areas.Admin.Services.Models.Albums;
using MusicStoreWeb.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStoreWeb.Areas.Admin.Services.Implementations
{
    public class AdminAlbumService : IAdminAlbumService
    {
        private readonly MusicStoreDbContext db;

        public AdminAlbumService(MusicStoreDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddSongToAlbumAsync(int id, int songId, int artistId)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(string title, decimal price, int amountOfSongs, int artistId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AdminAlbumDetailsServiceModel> DetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int id, string title, decimal price, int amountOfSongs, int artistId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetArtistIdByAlbumId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<AdminAlbumEditServiceModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsSongAddedAsync(int id, int songId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdminAlbumsListingServiceModel>> ListAllAsync(int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<int> TotalAsync()
        {
            throw new NotImplementedException();
        }
    }
}
