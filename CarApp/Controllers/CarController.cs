using Microsoft.AspNetCore.Mvc;
using CarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CarApp.Controllers
{
    public class CarController : Controller
    {
        private ICarRepository repository;
        private ICrudCarRepository crudRepository;
        private ICustomerCarRepository customerRepository;

        public CarController(ICarRepository repository, ICrudCarRepository crudCarRepository, ICustomerCarRepository customerCarRepository)
        {
            this.repository = repository;
            crudRepository = crudCarRepository;
            customerRepository = customerCarRepository;
        }
        public IActionResult ShowList()
        {
            return View("CarList", repository.Cars);
        }
        public IActionResult AddForm()
        {
            return View();
        }
        public IActionResult AddCar(Car carData) 
        {
            if (ModelState.IsValid)
            {
                crudRepository.Add(carData);
                return View("CarList", repository.Cars);
            }
            else
            {
                return View("AddForm");
            }
        }
        public IActionResult DeleteCar(int ID)
        {
            crudRepository.Delete(ID);
            return View("CarList", repository.Cars);
        }
        public IActionResult EditForm(int ID)
        {
            var currentCar = crudRepository.Find(ID);
            return View("EditForm", currentCar);
        }
        public IActionResult EditCar(Car carData)
        {

            if (ModelState.IsValid)
            {
                crudRepository.Update(carData);
                return View("CarList", repository.Cars);
            }
            else
            {
                return View("EditForm", carData);
            }
        }
        public IActionResult SearchForm()
        {
            return View("SearchForm");
        }
        public IActionResult SearchList(Car data)
        {
            var brandResult = customerRepository.FindByBrandName(data.Marka);
            var modelResult = customerRepository.FindByModelName(data.Model);
            if(brandResult.Count > 0 & modelResult.Count > 0)
            {
                var result = customerRepository.FindByModelName(data.Model);
                return View("SearchList", result);
            }
            else if(brandResult.Count > 0 & modelResult.Count <= 0)
            {
                var result = customerRepository.FindByBrandName(data.Marka);
                return View("SearchList", result);
            }
            else if (brandResult.Count <= 0 & modelResult.Count > 0)
            {
                var result = customerRepository.FindByModelName(data.Model);
                return View("SearchList", result);
            }
            else
            {
                return Json("NO PASS!");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
