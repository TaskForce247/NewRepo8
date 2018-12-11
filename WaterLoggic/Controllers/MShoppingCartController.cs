

using Microsoft.AspNetCore.Mvc;
using MService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLoggic.Core;
using WaterLoggic.Core.Models;
using WaterLoggic.Core.ViewModel;


namespace WaterLoggic.Controllers
{
    public class MShoppingCartController : Controller
    {
        List<Machine> machineList = new List<Machine>();
        public bool canuse = false;
        private readonly MachineRepositoryClient _machineRepository;
        private readonly IMShoppingCartService _shoppingCart;

        public MShoppingCartController(MachineRepositoryClient machineRepository, IMShoppingCartService shoppingCart)
        {
            _machineRepository = machineRepository;
            _shoppingCart = shoppingCart;
        }

        public async Task<IActionResult> Index()
        {
            await _shoppingCart.GetShoppingCartItemsAsync();
            var shoppingCartCountTotal = await _shoppingCart.GetCartCountAndTotalAmmountAsync();
            var shoppingCartViewModel = new MShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartItemsTotal = shoppingCartCountTotal.ItemCount,
                ShoppingCartTotal = shoppingCartCountTotal.TotalAmmount,
            };


            return View(shoppingCartViewModel);
        }
        [HttpPost]

        public async Task<IActionResult> AddToShoppingCart(int machineId)
        {
            
            var selectedMachine = await _machineRepository.GetMachineByIdAsync(machineId);
            if (selectedMachine == null || selectedMachine.stock == 0)
            {
                return NotFound();
            }
            if (selectedMachine.stock!= 0)
            {
                machineList.Add(selectedMachine);
                selectedMachine.stock = selectedMachine.stock - 1;
               
                await _shoppingCart.AddToCartAsync(selectedMachine);
                _machineRepository.UpdateMachineAsync(selectedMachine);
                canuse = true;
            }

        else { return NotFound(); }
          

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromShoppingCart(int machineId)
        {
            var selectedMachine = await _machineRepository.GetMachineByIdAsync(machineId);
            if (selectedMachine == null)
            {
                return NotFound();
            }
            selectedMachine.stock = selectedMachine.stock + 1;
            selectedMachine.available = true;
            await _shoppingCart.RemoveFromCartAsync(selectedMachine);
            _machineRepository.UpdateMachineAsync(selectedMachine);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAllCart()
        {
            await _shoppingCart.ClearCartAsync();
            return RedirectToAction("Index");
        }
    }
}
