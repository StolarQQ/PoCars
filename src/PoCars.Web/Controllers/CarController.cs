using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PoCars.Domain;
using PoCars.Services.Interfaces;
using PoCars.ViewModels;

namespace PoCars.Web.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly UserManager<IdentityUser> _userManager;

        public CarController(ICarService carService, UserManager<IdentityUser> userManager)
        {
            _carService = carService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var carViewModel = new CarIndexViewModel()
            {
                Title = "Cars for Sell",
                Cars = await _carService.GetAllAsync()
            };

            return View(carViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        public IActionResult Create()
        {
            var carViewModel = new CarViewModel
            {
                Title = "Test",
            };

            return View(carViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                car.UserId =  new Guid(_userManager.GetUserId(HttpContext.User));
                await _carService.AddAsync(car);
                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carService.GetByIdAsync(id);

            var editViewModel = new CarViewModel
            {
                Title = "Edit Car",
                Car = car
            };
            return View(editViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Car car)
        {
            await _carService.UpdateAsync(id, car);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _carService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}