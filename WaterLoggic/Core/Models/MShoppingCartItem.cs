
using MService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterLoggic.Core.Models
{
    public class MShoppingCartItem
    {

        public int Id { get; set; }

        public string MachineName { get; set; }
        public int MachineId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public Machine Machine { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
