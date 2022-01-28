using CarApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Controllers
{   
        [ApiController]
        [Route("api/recipients")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public class RestCarController : ControllerBase
        {
            private ICrudCarRepository _carRepository;

            public RestCarController(ICrudCarRepository carRepository)
            {
                _carRepository = carRepository;               
            }
            [HttpGet]
            public IActionResult Get()
            {

                try
                {
                    var allPricings = _carRepository.FindAll();
                    return Ok(allPricings);
                }
                catch (Exception)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
                }
            }

            [HttpGet("{id:int}")]
            public  IActionResult GetRecipientById(int id)
            {
                try
                {
                    var pricing = _carRepository.Find(id);
                    if (pricing != null)
                        return Ok(pricing);
                    else
                        return NotFound("Pricing with specified id does not exist");
                }
                catch (Exception)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
                }

            }

            [HttpPost]
            public IActionResult Add(Car car)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                       
                        _carRepository.Add(car);
                        return Ok("Car has been added!");
                    }
                    else
                        return BadRequest("");

                }
                catch (Exception ex)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
                }
            }

            [HttpPut("{id:int}")]
            public IActionResult Update(int id)
            {
                try
                {

                    var invoice = _carRepository.Find(id);
                    if (invoice != null)
                    {
                        _carRepository.Update(invoice);
                        return Ok("Car has been updated");
                    }
                    else
                    {
                        return NotFound("Specified Car does not exist");
                    }

                }
                catch (Exception ex)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
                }
            }

            [HttpDelete("{id:int}")]
            public  IActionResult Delete(int id)
            {
                try
                {

                    var car = _carRepository.Find(id);
                    if (car != null)
                    {
                        _carRepository.Delete(id);
                        return Ok("Pricing has been deleted");
                    }
                    else
                    {
                        return NotFound("Specified Pricing is not existing already.");
                    }

                }
                catch (Exception ex)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
                }
            }
        }
}
