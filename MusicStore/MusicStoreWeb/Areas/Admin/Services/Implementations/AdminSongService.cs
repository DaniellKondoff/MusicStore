using MusicStoreWeb.Areas.Admin.Services.Contracts;
using MusicStoreWeb.Areas.Admin.Services.Models.Songs;
using MusicStoreWeb.Data;
using MusicStoreWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStoreWeb.Areas.Admin.Services.Implementations
{
    public class AdminSongService : IAdminSongService
    {
        private readonly MusicStoreDbContext db;

        public AdminSongService(MusicStoreDbContext db)
        {
            this.db = db;
        }

        public Task<IEnumerable<AdminSongListingServiceModel>> AllAsync(int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdminSongBaseServiceModel>> AllBasicAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(string name, decimal price, double duration, int artistId, Ganre ganre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AdminSongDetailsServiceModel> DetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int id, string name, decimal price, double duration, int artistId, Ganre ganre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AdminSongEditServiceModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsGanreExist(int ganreValueId)
        {
            throw new NotImplementedException();
        }

        public Task<int> TotalAsync()
        {
            throw new NotImplementedException();
        }
    }
}
