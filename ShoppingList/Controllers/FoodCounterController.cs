using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using ShoppingList.Services.Interface;

namespace ShoppingList.Controllers
{
   /* [ApiVersion("2.0")]*/
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCounterController : ControllerBase
    {
        private readonly IFoodCounterInterface _foodCounterService;

        public FoodCounterController(IFoodCounterInterface foodCounterService)
        {
            _foodCounterService = foodCounterService;

        }

        // GET: api/FoodCounter
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<FoodCounter>>> Buylistdetails(int id)
        {

            try
            {
                var temp = await _foodCounterService.GetFoodCounterBuyListDetailsAsync(id);
                return Ok(temp);
            }

            catch (InvalidOperationException)
            {
                return BadRequest("Nem lehetett lekérni");
            }
        }

        // GET: api/FoodCounter/5
        [HttpGet("{id}", Name = "GetFoodCounter")]
        public async Task<ActionResult<FoodCounter>> GetAsync(int id)
        {
            try
            {
                return await _foodCounterService.GetFoodCounterAsync(id);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Nem lehetett lekérni");
            }


        }

        // POST: api/FoodCounter
        [HttpPost]
        public async Task<ActionResult<FoodCounter>> Post([FromBody] FoodCounter value)
        {
            if (value == null)
            {
                return BadRequest("Üres paraméter");
            }
            try
            {
                var temp = await _foodCounterService.InsertFoodCounterAsync(value);
                return Ok(temp);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Sikertelen beszúrás");
            }
        }

        // PUT: api/FoodCounter/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FoodCounter value)
        {
            if (value == null)
            {
                return BadRequest("Üres paraméter");
            }

            try
            {
                value.Modification = DateTime.Now;
                await _foodCounterService.UpdateFoodCounterAsync(value);
                return RedirectToAction("Food", new { id = value.Id });
            }
            catch
            {
                string response = "Nem sikerült a változtatás";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (id < 1 || id > int.MaxValue)
            {
                return BadRequest("Rossz ID");
            }
            try
            {
                await _foodCounterService.DeleteFoodCounterAsync(id);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Nincs ilyen Entitás");
            }
            return Ok("Törlés kész");

        }
    }
}
