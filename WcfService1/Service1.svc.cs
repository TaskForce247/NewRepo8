using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WaterLoggic.Core;
using WaterLoggic.Core.Dto;
using WaterLoggic.Core.Models;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IMachineRepository
    {
        public Task AddMachineAsync(Machine machine)
        {
            return AddMachineAsync(machine);
        }

        public void Delete(int id)
        {
            Delete(id);
        }

        public Task<IEnumerable<MachineNameIdDto>> GetAllMachinesNameId()
        {
            return GetAllMachinesNameId();
        }

        public Task<IEnumerable<MCategory>> GetCategoriesAsync()
        {
            return GetCategoriesAsync();
        }

        public Task<Machine> GetMachineById(int machineId)
        {
            return GetMachineById(machineId);
        }

        public Task<IEnumerable<Machine>> GetMachines(string category = null)
        {
            return GetMachines(category);

        }

        public void UpdateMachine(Machine machine)
        {
            UpdateMachine(machine);
        }
    }
}
