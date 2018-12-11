using WaterLoggic.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterLoggic.Core.ViewModel
{
    public class MyMOrderViewModel
    {

        public MOrderDto MOrderPlaceDetails { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlacedTime { get; set; }
        public IEnumerable<MyMachineOrderInfo> MachineOrderInfos { get; set; }

    }
    public class MyMachineOrderInfo
    {
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
