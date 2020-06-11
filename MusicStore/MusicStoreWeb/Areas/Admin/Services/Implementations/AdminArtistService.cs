using MusicStoreWeb.Areas.Admin.Services.Contracts;
using MusicStoreWeb.Areas.Admin.Services.Models.Artists;
using MusicStoreWeb.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStoreWeb.Areas.Admin.Services.Implementations
{
    public class AdminArtistService : IAdminArtistService
    {
        private readonly MusicStoreDbContext db;

        public AdminArtistService(MusicStoreDbContext db)
        {
            this.db = db;
        }

        public Task<IEnumerable<AdminArtistListingServiceModel>> AllAsync(int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdminBaseArtistServiceModel>> AllBasicAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(int id, string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int artistId)
        {
            throw new NotImplementedException();
        }

        public Task<AdminBaseArtistServiceModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> TotalAsync()
        {
            throw new NotImplementedException();
        }
    }
}
