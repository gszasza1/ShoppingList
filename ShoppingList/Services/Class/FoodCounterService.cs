using Microsoft.EntityFrameworkCore;
using ShoppingList.DBContext;
using ShoppingList.Models;
using ShoppingList.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services.Class
{
    public class FoodCounterService : IFoodCounterInterface
    {
        private readonly ShoppingListContext _context;

        public FoodCounterService(ShoppingListContext context)
        {
            _context = context;
        }

        public async Task<FoodCounter> GetFoodCounterAsync(int foodId)
        {
            return await _context.FoodCounters
                .SingleOrDefaultAsync(p => p.Id == foodId);
        }

        public async Task<IEnumerable<FoodCounter>> GetFoodCounterBuyListDetailsAsync(int buyListId)
        {
            return await _context.FoodCounters.Where(b => b.BuyListId.Equals(buyListId)).OrderBy(b => b.Counter).Include(p=>p.Foods).ToListAsync();
        }

        public async Task<FoodCounter> InsertFoodCounterAsync(FoodCounter newFood)
        {
            _context.FoodCounters.Add(newFood);

            await _context.SaveChangesAsync();

            return newFood;
        }

        public async Task UpdateFoodCounterAsync(FoodCounter updateFood)
        {

            var entry = _context.Attach(updateFood);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodCounterAsync(int foodId)
        {
            _context.FoodCounters.Remove(new FoodCounter { Id = foodId });

            await _context.SaveChangesAsync();

        }


    }
}
