using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterLoggic.Core;
using WaterLoggic.Core.ViewModel;

namespace WaterLoggic.Controllers
{
    public class MachineController : Controller
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IMCategoryRepository _mcategoryRepository;

        public MachineController(IMachineRepository machineRepository, IMCategoryRepository mcategoryRepository)
        {
            _machineRepository = machineRepository;
            _mcategoryRepository = mcategoryRepository;
        }

        [HttpGet("machines/{category?}")]
        public async Task<IActionResult> List(string category)
        {
            var selectedCategory = !string.IsNullOrWhiteSpace(category) ? category : null;
            var machinesListViewModel = new MachinesListViewModel
            {
                Machines = await _machineRepository.GetMachines(selectedCategory),
                CurrentCategory = selectedCategory ?? "All Machines"
            };
            return View(machinesListViewModel);
        }

        [HttpGet("machines/details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var machine = await _machineRepository.GetMachineById(id);

            return View(machine);
        }
    }
}