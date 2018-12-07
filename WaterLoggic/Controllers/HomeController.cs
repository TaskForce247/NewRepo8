
using WaterLoggic.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WaterLoggic.Core;

namespace WaterLoggic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMachineRepository _machineRepository;

        public HomeController(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomeViewModel
            {
                
            });
        }
    }
}