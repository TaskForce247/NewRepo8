using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WaterLoggic.Core.Models
{
    public class MCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Machine> Machines{ get; set; }

        public MCategory()
        {
            Machines = new Collection<Machine>();
        }
    }
}
