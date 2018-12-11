
using WaterLoggic.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WaterLoggic.Core;

using MService;

namespace WaterLoggic.Controllers
{
    public class HomeController : Controller
    {
        private readonly MachineRepositoryClient _machineRepository;

        public HomeController()
        {
           // _machineRepository = machineRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomeViewModel
            {
                
            });
        }
    }
}