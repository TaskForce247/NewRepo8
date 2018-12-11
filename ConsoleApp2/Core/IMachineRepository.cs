using WaterLoggic.Core.Dto;
using WaterLoggic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WaterLoggic.Core
{
    public interface IMachineRepository
    {

        Task<IEnumerable<Machine>> GetMachines(string category = null);

        Task<Machine> GetMachineById(int machineId);

        Task<IEnumerable<MachineNameIdDto>> GetAllMachinesNameId();

        void UpdateMachine(Machine machine);
        Task AddMachineAsync(Machine machine);
        void Delete(int id);
    }
}
