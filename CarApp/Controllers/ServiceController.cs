using CarApp.Models;
using CarApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Controllers
{
    public class ServiceController : Controller
    {
        ICarRepository _carRepository;
        private readonly ICarServiceRepository _carServiceRepository;
        public ServiceController(ICarRepository carRepository, ICarServiceRepository carServiceRepository)
        {
            _carRepository = carRepository;
            this._carServiceRepository = carServiceRepository;
        }
        public IActionResult Index()
        {
            return View("ServiceList", _carRepository.Cars);
        }
        public IActionResult AddService(int id)
        {
            _carServiceRepository.Add(id);
            return View("ServiceList", _carRepository.Cars);
        }
    }
}
