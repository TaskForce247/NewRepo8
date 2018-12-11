using WaterLoggic.Core.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLoggic.Core.Models;
using MService;

namespace WaterLoggic.Core.ViewModel
{
    public class MachineCreateUpdateViewModel
    {

        public IEnumerable<MCategory> Categories { get; set; }
        public MachineDto MachineDto { get; set; }

        public MachineCreateUpdateViewModel()
        {
            Categories = new List<MCategory>();
        }
    }
}

