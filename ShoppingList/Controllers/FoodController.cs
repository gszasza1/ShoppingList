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
        public async Task<IEnumerable<Food>> Get() =>
            
            await _foodService.GetFoodsAsync();

        // GET: api/Food/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Food> GetAsync(int id)
        {
            return await _foodService.GetFoodAsync(id);
        }

        // GET: api/Food/5
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<Food>> more(int id)
        {
            return await _foodService.GetFoodMoreThansAsync(id);
        }

        // POST: api/Food
        [HttpPost]
        public async Task<Food> Post([FromBody] Food newFood)
        {
            var temp = await _foodService.InsertFood(newFood);
            return temp;
        }

        // PUT: api/Food/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]  Food newFood)
        {
            if (newFood == null)
            {
                return BadRequest();
            }

           try
            {
                await _foodService.UpdateFoodAsync(newFood);
                return RedirectToAction("Food", new { id = newFood.Id });
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
                return BadRequest();
            }

            await _foodService.DeleteFoodAsync(id);
            return Ok();
        }
    }
}
