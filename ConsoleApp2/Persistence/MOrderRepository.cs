using WaterLoggic.Core.Dto;
using WaterLoggic.Core.Models;
using WaterLoggic.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLoggic.Core;


namespace WaterLoggic.Persistence
{
    public class MOrderRepository : IMOrderRepository
    {
        private readonly WaterLogicDbContext _context;
        private readonly IMShoppingCartService _shoppingCartService;

        public MOrderRepository(
            WaterLogicDbContext context,
            IMShoppingCartService mshoppingCartService)
        {
            _context = context;
            _shoppingCartService = mshoppingCartService;
        }

        public async Task CreateOrderAsync(MOrder morder)
        {
            morder.OrderPlacedTime = DateTime.Now;
            await _context.MOrders.AddAsync(morder);

            var MshoppingCartItems = await _shoppingCartService.GetShoppingCartItemsAsync();
          
            morder.OrderTotal = (await _shoppingCartService.GetCartCountAndTotalAmmountAsync()).TotalAmmount;

            await _context.MOrderDetails.AddRangeAsync(MshoppingCartItems.Select(e => new MOrderDetail
            {
                Qty = e.Qty,
                MachineName = e.MachineName,
                OrderId = morder.Id,
                Price = e.Machine.Price
            }));

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MyMOrderViewModel>> GetAllOrdersAsync()
        {
            return await _context.MOrders
                .Include(e => e.MOrderDetails)
                .Select(e => new MyMOrderViewModel
                {
                    OrderPlacedTime = e.OrderPlacedTime,
                    OrderTotal = e.OrderTotal,
                    MOrderPlaceDetails = new MOrderDto
                    {
                        AddressLine = e.AddressLine,
                        City = e.City,            
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        PhoneNumber = e.PhoneNumber                   
                    },
                    MachineOrderInfos = e.MOrderDetails.Select(o => new MyMachineOrderInfo
                    {
                        Name = o.MachineName,
                        Price = o.Price,
                        Qty = o.Qty
                    })
                })
                .ToListAsync();

        }
        public async Task<System.Collections.Generic.IEnumerable<MyMOrderViewModel>> GetAllOrdersAsync(string userId)
        {
            return await _context.MOrders
                .Where(e => e.UserId == userId)
                .Include(e => e.MOrderDetails)
                .Select(e => new MyMOrderViewModel
                {
                    OrderPlacedTime = e.OrderPlacedTime,
                    OrderTotal = e.OrderTotal,
                    MOrderPlaceDetails = new MOrderDto
                    {
                        AddressLine = e.AddressLine,
                        City = e.City,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        PhoneNumber = e.PhoneNumber
                    },
                    MachineOrderInfos = e.MOrderDetails.Select(o => new MyMachineOrderInfo
                    {
                        Name = o.MachineName,
                        Price = o.Price,
                        Qty = o.Qty
                    })
                })
                .ToListAsync();
        }
    }
}

