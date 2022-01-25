using CarApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Controllers
{
    [Authorize]
    [Authorize(Policy = "UsersAccess")]
    public class UserController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private ICustomerCarRepository customerRepository;
        public UserController(ICustomerCarRepository customerCarRepository)
        {
            customerRepository = customerCarRepository;
        }

        public IActionResult ShowMap()
        {
            return View("CarMap");
        }
        public IActionResult ShowPayment()
        {
            return View("Payment");
        }
        public IActionResult GetData()
        {
            return View("UserData");
        }
    }
}