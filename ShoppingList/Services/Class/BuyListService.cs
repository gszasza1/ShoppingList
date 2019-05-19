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
    public class BuyListService : IBuyListInterface
    {
        private readonly ShoppingListContext _context;

        public BuyListService(ShoppingListContext context)
        {
            _context = context;
        }

        public async Task<BuyList> GetBuyListAsync(int buyListId)
        {
            return await _context.BuyList
                .SingleOrDefaultAsync(p => p.Id == buyListId);
        }
        public async Task<IEnumerable<BuyList>> GetBuyLists()
        {
            return await _context.BuyList.ToListAsync();
        }
        public async Task<IEnumerable<BuyList>> GetBuyListsDetails(int id)
        {
            return await _context.BuyList.Include(p=>p.shoppingList).ThenInclude(po=>po.Foods).ToListAsync();
        }

        public async Task<BuyList> InsertBuyListAsync(BuyList newBuyList)
        {
            _context.BuyList.Add(newBuyList);

            await _context.SaveChangesAsync();

            return newBuyList;
        }

        public async Task UpdateBuyListAsync(BuyList updateBuyList)
        {

            var entry = _context.Attach(updateBuyList);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBuyListAsync(int buyListId)
        {
            _context.BuyList.Remove(new BuyList { Id = buyListId });
            var removeCounter = _context.FoodCounters.Where(p => p.BuyListId.Equals(buyListId));
            _context.FoodCounters.RemoveRange(removeCounter);

            await _context.SaveChangesAsync();

        }


    }
}
