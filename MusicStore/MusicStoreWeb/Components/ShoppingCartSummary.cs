﻿using Microsoft.AspNetCore.Mvc;
using MusicStoreWeb.Infrastructure.Extensions;
using MusicStoreWeb.Services.Contracts;
using System.Linq;

namespace MusicStoreWeb.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCartManager shoppingCartManager;

        public ShoppingCartSummary(IShoppingCartManager shoppingCartManager)
        {
            this.shoppingCartManager = shoppingCartManager;
        }

        public IViewComponentResult Invoke()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            var quantity = items.Sum(i => i.Quantity);

            return View(quantity);
        }
    }
}
