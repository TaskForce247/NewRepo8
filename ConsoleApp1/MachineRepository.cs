using WaterLoggic.Core.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLoggic.Core;
using WaterLoggic.Core.Models;

namespace WaterLoggic.Persistence
{
    public class MachineRepository : IMachineRepository
    {
        private readonly WaterLogicDbContext _context;

        public MachineRepository(WaterLogicDbContext context)
        {
            _context = context;
        }


        public async Task<Machine> GetMachineById(int machineId)
        {
            return await _context.Machines.FirstAsync(e => e.Id == machineId);
        }


        public async Task<IEnumerable<Machine>> GetMachines(string category = null)
        {

            var query = _context.Machines
                .Include(c => c.Category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(c => c.Category.Name == category);
            }

            return await query.ToListAsync();
        }

 
        public async Task<IEnumerable<MachineNameIdDto>> GetAllMachinesNameId()
        {
            return await _context.Machines
                 .Select(e => new MachineNameIdDto
                 {
                     Id = e.Id,
                     Name = e.Name
                 })
                 .ToListAsync();
        }


        public void UpdateMachine(Machine machine)
        {
            _context.Machines.Update(machine);
        }

        public async Task AddMachineAsync(Machine machine)
        {
            await _context.Machines.AddAsync(machine);
        }

        public void Delete(int id)
        {
            var machine = new Machine { Id = id };
            _context.Entry(machine).State = EntityState.Deleted;
        }
    }
}

