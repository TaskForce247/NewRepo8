using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterLoggic.Core.ViewModel
{
    public class MShoppingCartViewModel
    {
        public IMShoppingCartService ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public int ShoppingCartItemsTotal { get; set; }
    }
}
