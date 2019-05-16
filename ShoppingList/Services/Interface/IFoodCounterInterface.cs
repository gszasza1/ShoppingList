using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services.Interface
{
    public interface IFoodCounterInterface
    {
        Task DeleteFoodCounterAsync(int foodId);
        Task UpdateFoodCounterAsync(FoodCounter updateFood);
        Task<FoodCounter> InsertFoodCounterAsync(FoodCounter newFood);
        FoodCounter GetFoodCounter(int foodId);
        IEnumerable<FoodCounter> GetFoodCounterBuyListDetails(int buyListId);
    }
}
