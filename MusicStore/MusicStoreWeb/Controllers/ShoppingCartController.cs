﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicStoreWeb.Infrastructure.Extensions;
using MusicStoreWeb.Models.ShoppingCartViewModels;
using MusicStoreWeb.Services.Contracts;
using MusicStoreWeb.Services.Models.Albums;
using MusicStoreWeb.Services.Models.Songs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MusicStoreWeb.Infrastructure.Common.WebConstants;


namespace MusicStoreWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartManager shoppingCartManager;
        private readonly ISongService songService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IShoppingService shoppingService;
        private readonly IAlbumService albumsService;

        public ShoppingCartController(
            IShoppingCartManager shoppingCartManager,
            ISongService songService,
            UserManager<IdentityUser> userManager,
            IShoppingService shoppingService,
            IAlbumService albumsService)
        {
            this.shoppingCartManager = shoppingCartManager;
            this.songService = songService;
            this.userManager = userManager;
            this.shoppingService = shoppingService;
            this.albumsService = albumsService;
        }

        public async Task<IActionResult> Items()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var carItemsWithDetails = new CartItemsViewModel
            {
                ShoppingSongs = await this.GetSongCartItemsWithDetails(shoppingCartId),
                ShoppingAlbums = await this.GetAlbumCartItemsWithDetails(shoppingCartId)
            };

            return View(carItemsWithDetails);
        }

        public IActionResult AddToCart(int id, string name)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            this.shoppingCartManager.AddToCart(shoppingCartId, id, name);

            return RedirectToAction(nameof(Items));
        }

        [Authorize]
        public async Task<IActionResult> FinishOrder()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var itemsSongsWithDetails = await this.GetSongCartItemsWithDetails(shoppingCartId);
            var itemsAlbumsWithDetails = await this.GetAlbumCartItemsWithDetails(shoppingCartId);

            var userId = this.userManager.GetUserId(User);

            await this.shoppingService.CreateOrderAsync(userId, itemsSongsWithDetails, itemsAlbumsWithDetails);

            this.shoppingCartManager.Clear(shoppingCartId);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult RemoveFromCart(int id, string name)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            this.shoppingCartManager.RemoveFromCart(shoppingCartId, id, name);

            return RedirectToAction(nameof(Items));
        }

        private async Task<IEnumerable<SongShoppingDetailsServiceModel>> GetSongCartItemsWithDetails(string shoppingCartId)
        {
            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            var itemSongIds = items.Where(i => i.Title.EndsWith(SongShopping)).Select(i => i.ProductId);

            var itemSongQuantities = items.Where(i => i.Title.EndsWith(SongShopping)).ToDictionary(i => i.ProductId, i => i.Quantity);

            var itemsSongsWithDetails = await this.songService.SongShoppingDetails(itemSongIds);

            itemsSongsWithDetails.ToList().ForEach(i => i.Quantity = itemSongQuantities[i.Id]);

            return itemsSongsWithDetails;
        }

        private async Task<IEnumerable<AlbumShoppingDetailsServiceModels>> GetAlbumCartItemsWithDetails(string shoppingCartId)
        {
            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            var itemAlbumIds = items.Where(i => i.Title.EndsWith(AlbumShopping)).Select(i => i.ProductId);

            var itemAlbumQuantities = items.Where(i => i.Title.EndsWith(AlbumShopping)).ToDictionary(i => i.ProductId, i => i.Quantity);

            var itemsAlbumsWithDetails = await this.albumsService.AlbumsShoppingDetails(itemAlbumIds);

            itemsAlbumsWithDetails.ToList().ForEach(i => i.Quantity = itemAlbumQuantities[i.Id]);

            return itemsAlbumsWithDetails;
        }
    }
}
