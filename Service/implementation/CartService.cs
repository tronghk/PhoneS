﻿using DataAccess;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class CartService : ICartService
    {
        private ApplicationDbContext _context;
        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Cart cart)
        {
            await _context.Cart.AddAsync(cart);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Cart cart)
        {
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Cart cart)
        {
            _context.Cart.Update(cart);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Cart> GetAll()
        {
            foreach (var cart in _context.Cart)
            {
                yield return cart;
            }
        }
        public IEnumerable<Cart> GetAllByUsID(int usid)
        {
            return _context.Cart.Where(pi => pi.UserID == usid).AsEnumerable();
        }
        public Cart GetByCartID(int cartid)
        {
            return _context.Cart.Where(x => x.CartID == cartid).FirstOrDefault();
        }
        public async Task DeleteById(int cartid)
        {
            try
            {
                var cart = GetByCartID(cartid);
                _context.Cart.Remove(cart);
                await _context.SaveChangesAsync(true);
               
            }
            catch (Exception ex)
            {
            }
        }
        public async Task AddToCart(int usid, int proid)
        {
            var cartItem = _context.Cart.FirstOrDefault(c => c.UserID == usid && c.ProductID == proid);
            if (cartItem == null)
            {
                var newCartItem = new Cart()
                {
                    UserID = usid,
                    ProductID = proid,
                    Quantity = 1
                };
                await _context.Cart.AddAsync(newCartItem);
                await _context.SaveChangesAsync(true);
            }
        }

        public async Task<string> AddProduct(string userId, string productId, string quantity)
        {
            var cartItem = _context.Cart.FirstOrDefault(c => c.UserID == int.Parse(userId) && c.ProductID == int.Parse(productId));
            if(cartItem!= null)
            {
                cartItem.Quantity = int.Parse(quantity)+1;
                _context.Cart.Update(cartItem);
                await _context.SaveChangesAsync(true);
                return cartItem.Quantity.ToString();
            }
            return null;
            
        }

        public async Task<string> RemoveProduct(string userId, string productId, string quantity)
        {
            var cartItem = _context.Cart.FirstOrDefault(c => c.UserID == int.Parse(userId) && c.ProductID == int.Parse(productId));
            if (cartItem != null)
            {
                if (int.Parse(quantity) == 1)
                    return null;
                cartItem.Quantity = int.Parse(quantity) - 1;
                _context.Cart.Update(cartItem);
                await _context.SaveChangesAsync(true);
                return cartItem.Quantity.ToString();
            }
            return null;
        }
    }
}
