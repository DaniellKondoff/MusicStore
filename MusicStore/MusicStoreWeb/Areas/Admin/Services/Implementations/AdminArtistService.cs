using Microsoft.EntityFrameworkCore;
using MusicStoreWeb.Areas.Admin.Services.Contracts;
using MusicStoreWeb.Areas.Admin.Services.Models.Artists;
using MusicStoreWeb.Data;
using MusicStoreWeb.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MusicStoreWeb.Services.ServiceConstants;


namespace MusicStoreWeb.Areas.Admin.Services.Implementations
{
    public class AdminArtistService : IAdminArtistService
    {
        private readonly MusicStoreDbContext db;

        public AdminArtistService(MusicStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminArtistListingServiceModel>> AllAsync(int page = 1)
        {
            return await this.db
                .Artists
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * AdminArtistsListingPageSize)
                .Take(AdminArtistsListingPageSize)
                .Select(a => new AdminArtistListingServiceModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Songs = a.Songs.Count(),
                    Albums = a.Albums.Count()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminBaseArtistServiceModel>> AllBasicAsync()
        {
            return await this.db.Artists
                    .Select(a => new AdminBaseArtistServiceModel
                    {
                        Id = a.Id,
                        Name = a.Name
                    })
                    .ToListAsync();
        }

        public async Task CreateAsync(string name)
        {
            if (name == null)
            {
                return;
            }

            var artist = new Artist
            {
                Name = name
            };

            await this.db.Artists.AddAsync(artist);
            await this.db.SaveChangesAsync();

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var artist = await this.db.Artists.FindAsync(id);

            if (artist == null)
            {
                return false;
            }

            this.db.Artists.Remove(artist);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditAsync(int id, string name)
        {
            var artist = await this.db.Artists.FindAsync(id);

            if (artist == null)
            {
                return false;
            }

            artist.Name = name;

            this.db.Artists.Update(artist);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistAsync(int artistId)
        {
            return await this.db.Artists
                .AnyAsync(a => a.Id == artistId);
        }

        public async Task<AdminBaseArtistServiceModel> GetByIdAsync(int id)
        {
            return await this.db.Artists
                .Where(a => a.Id == id)
                .Select(a => new AdminBaseArtistServiceModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> TotalAsync()
        {
            return await this.db
                .Artists.CountAsync();
        }
    }
}
