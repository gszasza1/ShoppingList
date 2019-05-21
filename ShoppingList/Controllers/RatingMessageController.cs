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
    public class RatingMessageController : ControllerBase
    {
        private readonly IRatingMessageInterface _ratingMessageService;

        public RatingMessageController(IRatingMessageInterface ratingMessageService)
        {
            _ratingMessageService = ratingMessageService;
        }

     

        // GET: api/RatingMessage/5
        [HttpGet("{id}", Name = "GetRatingMessageSingle")]
        public async Task<FoodMessageRating> GetRatingMessageSingleAsync(int id)
        {
            return await _ratingMessageService.GetRatingMessageSingleAsync(id);
        }
        // GET: api/RatingMessage/5
        [HttpGet("{id}/rating", Name = "GetRatingStars")]
        public async Task<IEnumerable<FoodMessageRating>>GetRatingStarsAsync(int id)
        {
            return await _ratingMessageService.GetRatingStarsAsync(id);
        }

        [HttpGet("{id}/messages", Name = "GetRatingMessages")]
        public async Task<IEnumerable<FoodMessageRating>> GetRatingMessagesAsync(int id)
        {
            return await _ratingMessageService.GetRatingMessagesAsync(id);
        }

        [HttpGet("{id}/better", Name = "GetMoreThanRatingFood")]
        public async Task<IEnumerable<FoodMessageRating>> GetMoreThanRatingFoodAsync(int id)
        {
            return await _ratingMessageService.GetMoreThanRatingFoodAsync(id);
        }

        [HttpGet("{id}/all", Name = "GetTopMessages")]
        public async Task<IEnumerable<FoodMessageRating>> GetTopMessagesAsync(int id)
        {
            return await _ratingMessageService.GetTopMessagesAsync(id);
        }

        [HttpGet("{id}/count", Name = "GetTotalRating")]
        public async Task<int> GetTotalRatingAsync(int id)
        {
           return await _ratingMessageService.GetTotalRatingAsync();
        }

        // POST: api/RatingMessage
        [HttpPost]
        public async Task<FoodMessageRating> InsertRatingMessageSingleAsync([FromBody] FoodMessageRating value)
        {
            return await _ratingMessageService.InsertRatingMessageSingleAsync(value);
        }

        
    }
}
