using WaterLoggic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MService;

namespace WaterLoggic.Core.ViewModel
{
    public class MachinesListViewModel
    {
        public IEnumerable<Machine> Machines { get; set; }
        public string CurrentCategory { get; set; }

  
    }
}

