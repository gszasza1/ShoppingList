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
        public async Task<IEnumerable<Food>> Get()
        {
          // var temp= _foodService.InsertFood(new Food() {Name= "kacsa",UnitPrice= 10 });
          // var a = new ArrayList();
           // a.Add(temp);
            return _foodService.GetFoods();
        }

        // GET: api/Food/5
        [HttpGet("{id}", Name = "Get")]
        public Food Get(int id)
        {
            return _foodService.GetFood(id);
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
            await _foodService.UpdateFoodAsync(newFood);
            return NoContent();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Fooddisp(int id)
        {
            await _foodService.DeleteFoodAsync(id);
            return NoContent();
        }
    }
}
