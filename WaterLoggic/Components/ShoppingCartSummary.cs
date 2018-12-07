

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WaterLoggic.Core;
using WaterLoggic.Core.ViewModel;

namespace WaterLoggic.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IMShoppingCartService _shoppingCart;

        public ShoppingCartSummary(IMShoppingCartService shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ShoppingCartCountTotal = await _shoppingCart.GetCartCountAndTotalAmmountAsync();
            var shoppingCartViewModel = new MShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartItemsTotal = ShoppingCartCountTotal.ItemCount,
                ShoppingCartTotal = ShoppingCartCountTotal.TotalAmmount
            };
            return View(shoppingCartViewModel);
        }

    }
}
