
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel;
using WaterLoggic.Core.Models;
using MService;

namespace WaterLoggic.Core
{
    [ServiceContract]
    public interface IMShoppingCartService
    {
        
        string Id { get; set; }
        
        IEnumerable<MShoppingCartItem> MShoppingCartItems { get; set; }
        [OperationContract]
        Task<int> AddToCartAsync(Machine selectedMachine, int qty = 1);
        [OperationContract]
        Task ClearCartAsync();
        [OperationContract]
        Task<IEnumerable<MShoppingCartItem>> GetShoppingCartItemsAsync();
        [OperationContract]
        Task<int> RemoveFromCartAsync(Machine selectedMachine, int qty = -1); 

        Task<(int ItemCount, decimal TotalAmmount)> GetCartCountAndTotalAmmountAsync();
        Task RemoveFromCartAsync(Machine selectedMachine);
    }
}
