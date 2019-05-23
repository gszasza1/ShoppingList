using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using ShoppingList.Services.Interface;

namespace ShoppingList.ControllersV2
{
   /*
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
        public async Task<IEnumerable<FoodCounter>> BuylistdetailsAsync(int id)
        {

            return await _foodCounterService.GetFoodCounterBuyListDetailsAsync(id);

        }

        // GET: api/FoodCounter/5
        [HttpGet("{id}")]
        public async Task<FoodCounter> GetAsync(int id)
        {

            return await _foodCounterService.GetFoodCounterAsync(id);



        }

        // POST: api/FoodCounter
        [HttpPost]
        public async Task<FoodCounter> Post([FromBody] FoodCounter value)
        {

            return await _foodCounterService.InsertFoodCounterAsync(value);

        }

        // PUT: api/FoodCounter/5
        [HttpPut]
        public async Task Put([FromBody] FoodCounter value)
        {

            value.Modification = DateTime.Now;
            await _foodCounterService.UpdateFoodCounterAsync(value);


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {


            await _foodCounterService.DeleteFoodCounterAsync(id);


        }
    }*/
}
