using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services.Interface
{
    public interface IFoodInterface
    {
        Food GetFood(int foodId);
        Task UpdateFoodAsync(Food updatedProduct);
        Task DeleteFoodAsync(int productId);
        IEnumerable<Food> GetFoods();
        Task<Food> InsertFood(Food newFood);
    }
}
