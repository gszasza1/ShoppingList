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
    public class FoodCounterController : ControllerBase
    {
        private readonly IFoodCounterInterface _foodCounterService;

        public FoodCounterController(IFoodCounterInterface foodCounterService)
        {
            _foodCounterService = foodCounterService;

        }
        // GET: api/FoodCounter
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET: api/FoodCounter
        [HttpGet("[action]")]
        public IEnumerable<FoodCounter> Buylistdetails(int id)
        {
           
            return _foodCounterService.GetFoodCounterBuyListDetails(id);
        }

        // GET: api/FoodCounter/5
        [HttpGet("{id}", Name = "GetFoodCounter")]
        public FoodCounter Get(int id)
        {
            return _foodCounterService.GetFoodCounter(id);
        }

        // POST: api/FoodCounter
        [HttpPost]
        public async Task<FoodCounter> Post([FromBody] FoodCounter value)
        {
            var temp = await _foodCounterService.InsertFoodCounterAsync(value);
            return temp;
        }

        // PUT: api/FoodCounter/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FoodCounter value)
        {
            value.Modification = DateTime.Now;
            await _foodCounterService.UpdateFoodCounterAsync(value);
            return NoContent();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _foodCounterService.DeleteFoodCounterAsync(id);
            return NoContent();

        }
    }
}
