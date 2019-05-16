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
    public class BuyListController : ControllerBase
    {
        private readonly IBuyListInterface _buyListInterface;

        public BuyListController(IBuyListInterface buyListInterface)
        {
            _buyListInterface = buyListInterface;

        }


        // GET: api/BuyList
        [HttpGet]
        public IEnumerable<BuyList> Get()
        {
            return _buyListInterface.GetBuyLists();
        }

        // GET: api/BuyList/5
        [HttpGet("{id}", Name = "GetBuyList")]
        public IEnumerable<BuyList> Get(int id)
        {
            return _buyListInterface.GetBuyListsDetails(id);
        }

        // POST: api/BuyList
        [HttpPost]
        public async Task<BuyList> Post([FromBody] BuyList value)
        {
            var temp = await _buyListInterface.InsertBuyListAsync(value);
            return temp;
        }

        // PUT: api/BuyList/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] BuyList value)
        {
            await _buyListInterface.UpdateBuyListAsync(value);
            return NoContent();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _buyListInterface.DeleteBuyListAsync(id);
            return NoContent();

        }
    }
}
