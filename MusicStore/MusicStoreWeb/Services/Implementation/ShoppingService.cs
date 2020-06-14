using MusicStoreWeb.Data;
using MusicStoreWeb.Data.Models;
using MusicStoreWeb.Services.Contracts;
using MusicStoreWeb.Services.Models.Albums;
using MusicStoreWeb.Services.Models.Songs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreWeb.Services.Implementation
{
    public class ShoppingService : IShoppingService
    {
        private readonly MusicStoreDbContext db;

        public ShoppingService(MusicStoreDbContext db)
        {
            this.db = db;
        }

        public async Task CreateOrderAsync(string userId, IEnumerable<SongShoppingDetailsServiceModel> itemsWithDetails, IEnumerable<AlbumShoppingDetailsServiceModels> itemsAlbumsWithDetails)
        {
            var order = new Order
            {
                UserId = userId,
                TotalPrice = (itemsWithDetails.Sum(i => i.Price * i.Quantity) + itemsAlbumsWithDetails.Sum(a => a.Price * a.Quantity))
            };

            foreach (var songItem in itemsWithDetails)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = songItem.Id,
                    ProductPrice = songItem.Price,
                    Quantity = songItem.Quantity
                });
            }

            foreach (var albumItem in itemsAlbumsWithDetails)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = albumItem.Id,
                    ProductPrice = albumItem.Price,
                    Quantity = albumItem.Quantity
                });
            }

            this.db.Orders.Add(order);
            await this.db.SaveChangesAsync();
        }
    }
}
