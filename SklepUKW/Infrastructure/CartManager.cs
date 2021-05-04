using SklepUKW.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepUKW.Infrastructure
{
    public class CartManager
    {
        FilmsContext db;
        ISessionManager session;

        public CartManager(FilmsContext db, ISessionManager session)
        {
            this.db = db;
            this.session = session;
        }

        public List<CartItem> GetCartItems()
        {
            List<CartItem> items;

            if(session.Get<List<CartItem>>(Consts.CartSessionKey) == null)
            {
                items = new List<CartItem>();
            }
            else
            {
                items = session.Get<List<CartItem>>(Consts.CartSessionKey);
            }

            return items;
        }

        public void AddToCart(int filmId)
        {
            var cart = GetCartItems();
            var thisFilm = cart.Find(f => f.Film.FilmId == filmId);

            if(thisFilm != null)
            {
                thisFilm.Quantity++;
            }
            else
            {
                var newCartItem = db.Films.Where(f => f.FilmId == filmId).SingleOrDefault();

                if(newCartItem != null)
                {
                    var cartItem = new CartItem()
                    {
                        Film = newCartItem,
                        Quantity = 1,
                        Price = newCartItem.Price
                    };

                    cart.Add(cartItem);
                }
            }

            session.Set(Consts.CartSessionKey, cart);
        }


        public int RemoveFromCart(int filmId)
        {
            var cart = GetCartItems();
            var thisFilm = cart.Find(f => f.Film.FilmId == filmId);

            if(thisFilm != null)
            {
                if(thisFilm.Quantity > 1)
                {
                    thisFilm.Quantity--;
                    return thisFilm.Quantity;
                }
                else
                {
                    cart.Remove(thisFilm);
                }
            }

            return 0;
        }

        public int GetCartQuantity()
        {
            var cart = GetCartItems();
            var sum = cart.Sum(i => i.Quantity);

            return sum;
        }

        public decimal GetCartValue()
        {
            var cart = GetCartItems();
            var sum = cart.Sum(i => (i.Price * i.Quantity));

            return sum;
        }
    }
}