using WaterLoggic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLoggic.Core.ViewModel;

namespace WaterLoggic.Core
{
    public interface IMOrderRepository
    {
        Task CreateOrderAsync(MOrder mOrder);
        Task<IEnumerable<MyMOrderViewModel>> GetAllOrdersAsync();
        Task<IEnumerable<MyMOrderViewModel>> GetAllOrdersAsync(string userId);
    }
}
