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

        public Food GetFood(int foodId)
        {
            return _context.Foods
                .SingleOrDefault(p => p.Id == foodId);
        }

        public IEnumerable<Food> GetFoods()
        {
            var products = _context.Foods
                .ToList();

            return products;
        }

        public async Task<Food> InsertFood(Food newFood)
        {
            _context.Foods.Add(newFood);

            await _context.SaveChangesAsync();

            return newFood;
        }

        public async Task UpdateFoodAsync(int foodId, Food updateFood)
        {
            updateFood.Id = foodId;
            var entry = _context.Attach(updateFood);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodAsync(int foodId)
        {
            _context.Foods.Remove(new Food { Id = foodId });

            await _context.SaveChangesAsync();

        }

    }
}
