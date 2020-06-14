﻿using MusicStoreWeb.Services.Models.ShoppingCarts;
using System.Collections.Generic;

namespace MusicStoreWeb.Services.Contracts
{
    public interface IShoppingCartManager
    {
        void AddToCart(string id, int productId, string title);

        void RemoveFromCart(string id, int productId, string title);

        IEnumerable<CartItem> GetItems(string id);

        void Clear(string id);
    }
}
