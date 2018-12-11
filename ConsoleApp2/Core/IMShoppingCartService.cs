
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel;
using WaterLoggic.Core.Models;

namespace WaterLoggic.Core
{
    [ServiceContract]
    public interface IMShoppingCartService
    {
        
        string Id { get; set; }
        
        IEnumerable<MShoppingCartItem> MShoppingCartItems { get; set; }
        [OperationContract]
        Task<int> AddToCartAsync(Machine machine, int qty = 1);
        [OperationContract]
        Task ClearCartAsync();
        [OperationContract]
        Task<IEnumerable<MShoppingCartItem>> GetShoppingCartItemsAsync();
        [OperationContract]
        Task<int> RemoveFromCartAsync(Machine machine);
        [OperationContract]
        Task<(int ItemCount, decimal TotalAmmount)> GetCartCountAndTotalAmmountAsync();
    }
}
