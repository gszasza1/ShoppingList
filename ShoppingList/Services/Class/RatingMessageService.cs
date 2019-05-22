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
    public class RatingMessageService : IRatingMessageInterface
    {
        private readonly ShoppingListContext _context;

        public RatingMessageService(ShoppingListContext context)
        {
            _context = context;
        }

        public async Task<FoodMessageRating> GetRatingMessageSingleAsync(int foodMessageId)
        {
            return await _context.FoodMessageRating
                .Include(p =>p.Messages)
                .Include(p => p.Rating)
                .SingleOrDefaultAsync(p => p.Id == foodMessageId);
        }

        public async Task<IEnumerable<FoodMessageRating>> GetRatingStarsAsync(int foodId)
        {
            return await _context.FoodMessageRating
                .Include(p =>p.Rating)
                .Where(p => p.FoodId == foodId).ToListAsync();
        }

        public async Task<int> GetTotalRatingAsync()
        {
            return await _context.FoodMessageRating.CountAsync();
        }
        

        public async Task<IEnumerable<FoodMessageRating>> GetRatingMessagesAsync(int foodId)
        {
            return await _context.FoodMessageRating
                .Include(p => p.Messages)
                .Where(p => p.FoodId == foodId).ToListAsync();
        }

        public async Task<IEnumerable<FoodMessageRating>> GetTopMessagesAsync(int foodId)
        {
            return await _context.FoodMessageRating
                .Include(p => p.Messages)
                .Include(p => p.Rating)
                .Where(p => p.FoodId == foodId).ToListAsync();
        }

        public async Task<IEnumerable<FoodMessageRating>> GetMoreThanRatingFoodAsync(int foodId)
        {
            return await _context.FoodMessageRating
                .Include(p => p.Messages)
                .Include(p => p.Rating)
                .Include(ps => ps.Foods)
                .Where(p => p.Rating.Stars >= foodId).ToListAsync();
        }

        public async Task<FoodMessageRating> InsertRatingMessageSingleAsync(FoodMessageRating newFoodMessageRating)
        {
            _context.FoodMessageRating.Add(newFoodMessageRating);

            await _context.SaveChangesAsync();
            return newFoodMessageRating;
        }


    }
}
