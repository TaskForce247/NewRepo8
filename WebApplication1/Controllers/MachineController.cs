using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WaterLoggic.Core;
using WaterLoggic.Core.ViewModel;
using WebApplication1.ServiceReference1;

namespace WaterLoggic.Controllers
{
    public class MachineController : Controller
    {
        private readonly MachineRepositoryClient _machineRepository;
        //private readonly IMCategoryRepository _mcategoryRepository;

        public MachineController(MachineRepositoryClient machineRepository)
        {
            _machineRepository = machineRepository;
           // _mcategoryRepository = mcategoryRepository;
        }

        [HttpGet("machines/{category?}")]
        public async Task<ActionResult> List(string category)
        {
            var selectedCategory = !string.IsNullOrWhiteSpace(category) ? category : null;
            var machinesListViewModel = new MachinesListViewModel
            {
              //  Machines = await _machineRepository.GetMachinesAsync(selectedCategory),
                CurrentCategory = selectedCategory ?? "All Machines"
            };
            return View(machinesListViewModel);
        }

        [HttpGet("machines/details/{id}")]
        public async Task<ActionResult> Details(int id)
        {

            var machine = await _machineRepository.GetMachineByIdAsync(id);

            return View(machine);
        }
    }
}