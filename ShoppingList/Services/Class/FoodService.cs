using Microsoft.EntityFrameworkCore;
using ShoppingList.DBContext;
using ShoppingList.Models;
using ShoppingList.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services
{
    public class FoodService : IFoodInterface
    {
        private readonly ShoppingListContext _context;

        public FoodService(ShoppingListContext context)
        {
            _context = context;
        }

        public async Task<Food> GetFoodAsync(int foodId)
        {
            return await _context.Foods
                .SingleOrDefaultAsync(p => p.Id == foodId);
        }

        public async Task<IEnumerable<Food>> GetFoodsAsync()
        {
            var products = await _context.Foods
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Food>> GetFoodMoreThansAsync(int value)
        {
            var products = await _context.Foods
                .Where(p => p.UnitPrice >= value)
                .ToListAsync();

            return products;
        }

        public async Task<Food> InsertFood(Food newFood)
        {
            _context.Foods.Add(newFood);

            await _context.SaveChangesAsync();

            return newFood;
        }

        public async Task UpdateFoodAsync(Food updateFood)
        {

            var entry = _context.Attach(updateFood);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodAsync(int foodId)
        {

            var temp = _context.Foods.FirstOrDefault(x => x.Id == foodId);
                 

            if (temp != null)
            {
                _context.Foods.Remove(temp);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw new Exception("Entity not found");
                }

            }
  
        }

    }
}
