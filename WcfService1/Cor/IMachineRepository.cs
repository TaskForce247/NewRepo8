using WaterLoggic.Core.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel;
using WaterLoggic.Core.Models;

namespace WaterLoggic.Core
{
    [ServiceContract]
    public interface IMachineRepository 
    {
        [OperationContract]
        Task<IEnumerable<Machine>> GetMachines(string category = null);
        [OperationContract]
        Task<Machine> GetMachineById(int machineId);
        [OperationContract]
        Task<IEnumerable<MachineNameIdDto>> GetAllMachinesNameId();
        [OperationContract]
        void UpdateMachine(Machine machine);
        [OperationContract]
        Task AddMachineAsync(Machine machine);
        [OperationContract]
        void Delete(int id);
        [OperationContract]
        Task<IEnumerable<MCategory>> GetCategoriesAsync();
    }
}
