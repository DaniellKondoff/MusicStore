using Microsoft.EntityFrameworkCore;
using MusicStoreWeb.Data;
using MusicStoreWeb.Services.Contracts;
using MusicStoreWeb.Services.Models.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MusicStoreWeb.Services.ServiceConstants;


namespace MusicStoreWeb.Services.Implementation
{
    public class SongService : ISongService
    {
        private readonly MusicStoreDbContext db;

        public SongService(MusicStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<SongListingServiceModel>> AllAsync(int page = 1)
        {
            return await this.db.Songs
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * SongListingPageSize)
                .Take(SongListingPageSize)
                .Select(a => new SongListingServiceModel
                {
                    Id = a.Id,
                    Artist = a.Artist.Name,
                    Name = a.Name
                })
                .ToListAsync();
        }

        public async Task<SongDetailsServiceModel> DetailsAsync(int id)
        {
            return await this.db.Songs
                .Where(s => s.Id == id)
                .Select(a => new SongDetailsServiceModel
                {
                    Id =a.Id,
                    Artist = a.Artist.Name,
                    Name = a.Name,
                    Price = a.Price,
                    Ganre = a.Ganre,
                    Duration = a.Duration
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SongListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Songs
                .OrderByDescending(s => s.Id)
                .Where(s => s.Name.ToLower().Contains(searchText.ToLower()))
                .Select(a => new SongListingServiceModel
                {
                    Id = a.Id,
                    Artist = a.Artist.Name,
                    Name = a.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SongShoppingDetailsServiceModel>> SongShoppingDetails(IEnumerable<int> itemIds)
        {
            return await this.db
                .Songs
                .Where(s => itemIds.Contains(s.Id))
                .Select(a => new SongShoppingDetailsServiceModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    Quantity = 0
                })
                .ToListAsync();
        }

        public async Task<int> TotalAsync()
        {
            return await this.db.Songs.CountAsync();
        }
    }
}
