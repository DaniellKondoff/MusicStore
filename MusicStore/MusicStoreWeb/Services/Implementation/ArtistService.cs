using Microsoft.EntityFrameworkCore;
using MusicStoreWeb.Data;
using MusicStoreWeb.Services.Contracts;
using MusicStoreWeb.Services.Models.Arists;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MusicStoreWeb.Services.ServiceConstants;

namespace MusicStoreWeb.Services.Implementation
{
    public class ArtistService : IArtistService
    {
        private readonly MusicStoreDbContext db;

        public ArtistService(MusicStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ArtistListingServiceModel>> AllAsync(int page = 1)
        {
            return await this.db
                .Artists
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * ArtistsListingPageSize)
                .Take(ArtistsListingPageSize)
                .Select(a => new ArtistListingServiceModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Albums = a.Albums.Count,
                    Songs = a.Albums.Count
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ArtistListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Artists
                .OrderByDescending(a => a.Id)
                .Where(a => a.Name.ToLower().Contains(searchText.ToLower()))
                .Select(a => new ArtistListingServiceModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Albums = a.Albums.Count,
                    Songs = a.Albums.Count
                })
                .ToListAsync();
        }

        public async Task<int> TotalAsync()
        {
            return await this.db.Artists.CountAsync();
        }
    }
}
