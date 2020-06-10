using Microsoft.EntityFrameworkCore;
using MusicStoreWeb.Data;
using MusicStoreWeb.Services.Contracts;
using MusicStoreWeb.Services.Models.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MusicStoreWeb.Services.ServiceConstants;

namespace MusicStoreWeb.Services.Implementation
{
    public class AlbumService : IAlbumService
    {
        private readonly MusicStoreDbContext db;
        public AlbumService(MusicStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AlbumShoppingDetailsServiceModels>> AlbumsShoppingDetails(IEnumerable<int> itemAlbumsIds)
        {
            return await this.db
               .Albums
               .Where(s => itemAlbumsIds.Contains(s.Id))
               .Select(a => new AlbumShoppingDetailsServiceModels
               {
                   Id = a.Id,
                   Name = a.Title,
                   Price = a.Price,
                   Quantity = a.AmountOfSongs
               })
               .ToListAsync();
        }

        public async Task<AlbumDetailsServiceModel> DetailsAsync(int id)
        {
            return await this.db.Albums
                .Where(a => a.Id == id)
                .Select(a => new AlbumDetailsServiceModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Songs = a.Songs.Select(s => s.Song.Name),
                    Artist = a.Artist.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AlbumsListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Albums
                .OrderByDescending(s => s.Id)
                .Where(s => s.Title.ToLower().Contains(searchText.ToLower()))
                .Select(a => new AlbumsListingServiceModel
                {
                    Id = a.Id,
                    Artist = a.Artist.Name,
                    AmountOfSongs = a.AmountOfSongs,
                    Price = a.Price,
                    Title = a.Title
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AlbumsListingServiceModel>> ListAllAsync(int page = 1)
        {
            return await this.db
               .Albums
               .OrderByDescending(a => a.Id)
               .Skip((page - 1) * AlbumsListingPageSize)
               .Take(AlbumsListingPageSize)
               .Select(a => new AlbumsListingServiceModel
               {
                   Id = a.Id,
                   Artist = a.Artist.Name,
                   AmountOfSongs = a.AmountOfSongs,
                   Price = a.Price,
                   Title = a.Title
               })
               .ToListAsync();
        }

        public async Task<int> TotalAsync()
        {
            return await this.db.Albums.CountAsync();
        }
    }
}
