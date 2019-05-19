using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<IEnumerable<BuyList>> GetAsync()
        {            
            return await _buyListInterface.GetBuyLists(); 
               
        }

        // GET: api/BuyList/5
        [HttpGet("{id}", Name = "GetBuyList")]
        public async Task<IEnumerable<BuyList>> GetAsync(int id)
        {
            return await _buyListInterface.GetBuyListsDetails(id);
        }

        // POST: api/BuyList
        [HttpPost]
        public async Task<ActionResult<BuyList>> Post([FromBody] BuyList value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            await _buyListInterface.InsertBuyListAsync(value);
            return CreatedAtAction(nameof(GetAsync), new { id = value.Id }, value); 
        }

        // PUT: api/BuyList/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] BuyList value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            
            try
            {
                await _buyListInterface.UpdateBuyListAsync(value);
                return RedirectToAction("BuyList", new { id = value.Id });
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
            if (id == null || id<1 || id>int.MaxValue)
            {
                return BadRequest();
            }

            await _buyListInterface.DeleteBuyListAsync(id);
            return Ok();

        }
    }
}
