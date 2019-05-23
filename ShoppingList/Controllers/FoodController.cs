using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;
using ShoppingList.Services.Interface;

namespace ShoppingList.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodInterface _foodService;

        public FoodController(IFoodInterface foodService)
        {
            _foodService = foodService;

        }

        // GET: api/Food
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> Get()
        {
            try
            {
             var temp =   await _foodService.GetFoodsAsync();
                return Ok(temp);
            }

            catch (InvalidOperationException)
            {
                return BadRequest("nem lehetett lekérni");
            }


        }
        // GET: api/Food/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Food>> GetAsync(int id)
        {
            
            try
            {
                var temp =  await _foodService.GetFoodAsync(id);
                return Ok(temp);
            }

            catch (InvalidOperationException)
            {
                return BadRequest("nem lehetett lekérni");
            }
        }

        // GET: api/Food/5
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<Food>> more(int id)
        {
            return await _foodService.GetFoodMoreThansAsync(id);
        }

        // POST: api/Food
        [HttpPost]
        public async Task<ActionResult<Food>> Post([FromBody] Food newFood)
        {
            try
            {
                var temp = await _foodService.InsertFood(newFood);
                return Ok(temp);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Nincs ilyen Entitás");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Adatbázis hiba");
            }



        }

        // PUT: api/Food/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]  Food newFood)
        {
            if (newFood == null)
            {
                return BadRequest("Üres paraméter");
            }

            try
            {
                await _foodService.UpdateFoodAsync(newFood);
                return Ok("Változás történt");
            }
            catch
            {
                string response = "Nem sikerült a változtatás";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Fooddisp(int id)
        {
            if (id == null || id < 1 || id > int.MaxValue)
            {
                return BadRequest("Rossz ID");
            }
            try
            {
                await _foodService.DeleteFoodAsync(id);
                return Ok("Törlés kész");
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Nincs ilyen Entitás");
            }
            catch(InvalidOperationException)
            {
                return BadRequest("Adatbázis hiba");
            }
            
        }
    }
}
