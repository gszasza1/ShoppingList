using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services.Interface
{
    public interface IRatingMessageInterface
    {

        Task<FoodMessageRating> GetRatingMessageSingleAsync(int foodMessageId);//
        Task<IEnumerable<FoodMessageRating>> GetRatingStarsAsync(int foodId);//
        Task<IEnumerable<FoodMessageRating>> GetRatingMessagesAsync(int foodId);//
        Task<FoodMessageRating> InsertRatingMessageSingleAsync(FoodMessageRating newFoodMessageRating);//
        Task<IEnumerable<FoodMessageRating>> GetMoreThanRatingFoodAsync(int foodId);
        Task<IEnumerable<FoodMessageRating>> GetTopMessagesAsync(int foodId);
        Task<int> GetTotalRatingAsync();
    }
}
