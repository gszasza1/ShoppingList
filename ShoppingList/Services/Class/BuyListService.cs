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

        public BuyList GetBuyList(int buyListId)
        {
            return _context.BuyList
                .SingleOrDefault(p => p.Id == buyListId);
        }
        public IEnumerable<BuyList> GetBuyLists()
        {
            return _context.BuyList.ToList();
        }
        public IEnumerable<BuyList> GetBuyListsDetails(int id)
        {
            return _context.BuyList.Include(p=>p.shoppingList).ThenInclude(po=>po.Foods);
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

        public async Task DeleteBuyListAsync(int foodId)
        {
            _context.BuyList.Remove(new BuyList { Id = foodId });

            await _context.SaveChangesAsync();

        }


    }
}
