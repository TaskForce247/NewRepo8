using AutoMapper;
using WaterLoggic.Core;
using WaterLoggic.Core.Dto;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using WaterLoggic.Core.ViewModel;
using WaterLoggic.Core.Models;
using System.Transactions;

namespace MachineShop.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/admin/manageMachines")]
    public class AdminController : Controller
    {
        private readonly IMOrderRepository _orderRepository;
        private readonly IMachineRepository _machineRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMCategoryRepository _categoryRepository;

        public AdminController(
            IMOrderRepository orderRepository,
            IMachineRepository machineRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMCategoryRepository categoryRepository)
        {
            _orderRepository = orderRepository;
            _machineRepository = machineRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        [HttpGet("allOrders")]
        public async Task<IActionResult> AllOrders()
        {
            ViewBag.ActionTitle = "All Orders";
            var orders = await _orderRepository.GetAllOrdersAsync();
            return View(orders);
        }

        [HttpGet("")]
        public async Task<IActionResult> ManageMachines()
        {
            var machines = await _machineRepository.GetAllMachinesNameId();
            return View(machines);
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddMachine()
        {
            var category = await _categoryRepository.GetCategories();
            return View(new MachineCreateUpdateViewModel
            {
                Categories = category
            });
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddMachine(MachineDto machineDto)
        {
            if (!ModelState.IsValid)
            {
                var category = await _categoryRepository.GetCategories();
                return View(new MachineCreateUpdateViewModel
                {
                    MachineDto = machineDto,
                    Categories = category
                });
            }
            var machine = _mapper.Map<MachineDto, Machine>(machineDto);
            await _machineRepository.AddMachineAsync(machine);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("ManageMachines");
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> EditMachine(int id, byte[] rowversion)
        {
            var machine = await _machineRepository.GetMachineById(id);
            var machineDto = _mapper.Map<Machine, MachineDto>(machine);
            var category = await _categoryRepository.GetCategories();

            return View(new MachineCreateUpdateViewModel
            {
                Categories = category,
                MachineDto = machineDto
            });
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> EditMachine(int id, [FromForm]MachineDto machineDto)
        {
            //try
            //{
              //  using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                //{
                    if (!ModelState.IsValid)
                    {
                        var category = await _categoryRepository.GetCategories();
                        return View(new MachineCreateUpdateViewModel
                        {
                            Categories = category,
                            MachineDto = machineDto
                        });
                    }
                    var machine = _mapper.Map<MachineDto, Machine>(machineDto);
                    machine.Id = id;

                    _machineRepository.UpdateMachine(machine);
                    await _unitOfWork.CompleteAsync();
                    return RedirectToAction("ManageMachines");
                   // tran.Complete();
                }
                    

        

           
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            _machineRepository.Delete(id);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }


    }
}