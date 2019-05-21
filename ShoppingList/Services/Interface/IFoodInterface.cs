using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services.Interface
{
    public interface IFoodInterface
    {
        Task<Food> GetFoodAsync(int foodId);
        Task UpdateFoodAsync(Food updatedProduct);
        Task DeleteFoodAsync(int productId);
        Task<IEnumerable<Food>> GetFoodsAsync();
        Task<Food> InsertFood(Food newFood);
        Task<IEnumerable<Food>> GetFoodMoreThansAsync(int value);
    }
}
