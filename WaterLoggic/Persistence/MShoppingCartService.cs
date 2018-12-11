using WaterLoggic.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLoggic.Core;

using MService;

namespace WaterLoggic.Persistence
{
    public class MShoppingCartService : IMShoppingCartService
    {

        private readonly WaterLogicDbContext _context;

        public string Id { get; set; }
        public IEnumerable<MShoppingCartItem> MShoppingCartItems { get; set; }

        private MShoppingCartService(WaterLogicDbContext context)
        {
            _context = context;
        }

        public static MShoppingCartService GetCart(IServiceProvider services)
        {
            var httpContext = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
            var context = services.GetRequiredService<WaterLogicDbContext>();

            var request = httpContext.Request;
            var response = httpContext.Response;

            var cardId = request.Cookies["CartId-cookie"] ?? Guid.NewGuid().ToString();

            response.Cookies.Append("CartId-cookie", cardId, new CookieOptions
            {
                Expires = DateTime.Now.AddMonths(2)
            });

            return new MShoppingCartService(context)
            {
                Id = cardId
            };
        }

        public async Task<int> AddToCartAsync(Machine machine, int qty = 1)
        {
            return await AddOrRemoveCart(machine, qty);

        }

        public async Task<int> RemoveFromCartAsync(Machine machine)
        {
            return await AddOrRemoveCart(machine, -1);
        }

        public async Task<IEnumerable<MShoppingCartItem>> GetMShoppingCartItemsAsync()
        {
            MShoppingCartItems = MShoppingCartItems ?? await _context.MShoppingCartItems
                .Where(e => e.ShoppingCartId == Id)
                .Include(e => e.Machine)
                .ToListAsync();

            return MShoppingCartItems;
        }

        public async Task ClearCartAsync()
        {
            var shoppingCartItems = _context
                .MShoppingCartItems
                .Where(s => s.ShoppingCartId == Id);

            _context.MShoppingCartItems.RemoveRange(shoppingCartItems);

            MShoppingCartItems = null; //reset
            await _context.SaveChangesAsync();
        }

        public async Task<(int ItemCount, decimal TotalAmmount)> GetCartCountAndTotalAmmountAsync()
        {
            var subTotal = MShoppingCartItems?
                .Select(c => c.Machine.Price * c.Qty) ??
                await _context.MShoppingCartItems
                .Where(c => c.ShoppingCartId == Id)
                .Select(c => c.Machine.Price * c.Qty)
                .ToListAsync();
           
            return (subTotal.Count(), subTotal.Sum());
        }

        private async Task<int> AddOrRemoveCart(Machine machine, int qty)
        {


            var shoppingCartItem = await _context.MShoppingCartItems
                            .SingleOrDefaultAsync(s => s.MachineId == machine.Id && s.ShoppingCartId == Id);
            
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new MShoppingCartItem
                {
                    ShoppingCartId = Id,
                    Machine = machine,
                    Qty = 0
                };

                await _context.MShoppingCartItems.AddAsync(shoppingCartItem);
                

            }

            shoppingCartItem.Qty += qty;

            if (shoppingCartItem.Qty <= 0)
            {
                shoppingCartItem.Qty = 0;
                _context.MShoppingCartItems.Remove(shoppingCartItem);
            }

            await _context.SaveChangesAsync();

            MShoppingCartItems = null; // Reset

            return await Task.FromResult(shoppingCartItem.Qty);
        }

        public async Task<IEnumerable<MShoppingCartItem>> GetShoppingCartItemsAsync()
        {
            MShoppingCartItems = MShoppingCartItems ?? await _context.MShoppingCartItems
             .Where(e => e.ShoppingCartId == Id)
             .Include(e => e.Machine)
             .ToListAsync();

            return MShoppingCartItems;
        }

        public Task<int> RemoveFromCartAsync(Machine selectedMachine, int qty = -1)
        {
            throw new NotImplementedException();
        }

        Task IMShoppingCartService.RemoveFromCartAsync(Machine selectedMachine)
        {
            throw new NotImplementedException();
        }
    }
}
