using System;
using System.Collections;
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
        public IEnumerable<Food> Get()
        {
          // var temp= _foodService.InsertFood(new Food() {Name= "kacsa",UnitPrice= 10 });
          // var a = new ArrayList();
           // a.Add(temp);
            return _foodService.GetFoods();
        }

        // GET: api/Food/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Food
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Food/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
