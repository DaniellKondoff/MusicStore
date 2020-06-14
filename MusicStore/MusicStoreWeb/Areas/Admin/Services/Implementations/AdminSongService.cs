using Microsoft.EntityFrameworkCore;
using MusicStoreWeb.Areas.Admin.Services.Contracts;
using MusicStoreWeb.Areas.Admin.Services.Models.Songs;
using MusicStoreWeb.Data;
using MusicStoreWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MusicStoreWeb.Services.ServiceConstants;


namespace MusicStoreWeb.Areas.Admin.Services.Implementations
{
    public class AdminSongService : IAdminSongService
    {
        private readonly MusicStoreDbContext db;

        public AdminSongService(MusicStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminSongListingServiceModel>> AllAsync(int page = 1)
        {
            return await this.db.Songs
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * AdminSongListingPageSize)
                .Take(AdminSongListingPageSize)
                .Select(s => new AdminSongListingServiceModel
                {
                    Name = s.Name,
                    Id = s.Id,
                    Artist = s.Artist.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminSongBaseServiceModel>> AllBasicAsync(int id)
        {
            return await this.db.Songs
                .OrderByDescending(s => s.Id)
                .Where(s => s.ArtistId == id)
                .Select(s => new AdminSongBaseServiceModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
        }

        public async Task CreateAsync(string name, decimal price, double duration, int artistId, Ganre ganre)
        {
            var song = new Song
            {
                Name = name,
                Price = price,
                Duration = duration,
                ArtistId = artistId,
                Ganre = ganre
            };

            await this.db.Songs.AddAsync(song);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var song = await this.db.Songs.FindAsync(id);

            if (song == null)
            {
                return false;
            }

            this.db.Songs.Remove(song);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<AdminSongDetailsServiceModel> DetailsAsync(int id)
        {
            return await this.db.Songs
                .Where(s => s.Id == id)
                .Select(s => new AdminSongDetailsServiceModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Artist = s.Artist.Name,
                    Duration = s.Duration,
                    Price = s.Price,
                    Ganre = s.Ganre
                })
                .FirstOrDefaultAsync();
        }

        public async Task EditAsync(int id, string name, decimal price, double duration, int artistId, Ganre ganre)
        {
            var song = await this.db.Songs.FindAsync(id);

            if (song == null)
            {
                return;
            }

            song.Name = name;
            song.Price = price;
            song.Duration = duration;
            song.ArtistId = artistId;
            song.Ganre = ganre;

            this.db.Songs.Update(song);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await this.db.Songs
                .AnyAsync(s => s.Id == id);
        }

        public async Task<AdminSongEditServiceModel> GetByIdAsync(int id)
        {
            return await this.db.Songs
                .Where(s => s.Id == id)
                .Select(s => new AdminSongEditServiceModel
                {
                    Name = s.Name,
                    Artist = s.Artist.Name,
                    Duration = s.Duration,
                    Price = s.Price
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> TotalAsync()
        {
            return await this.db.Songs.CountAsync();
        }

        public bool IsGanreExist(int ganreValueId)
        {
            var ganresCount = Enum.GetValues(typeof(Ganre)).Length;

            return ganreValueId >= 0 && ganreValueId < ganresCount;
        }
    }
}
