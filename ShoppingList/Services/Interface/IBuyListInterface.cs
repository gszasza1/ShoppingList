using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services.Interface
{
    public interface IBuyListInterface
    {
        Task DeleteBuyListAsync(int foodId);
        Task UpdateBuyListAsync(BuyList updateBuyList);
        Task<BuyList> InsertBuyListAsync(BuyList newBuyList);
        Task<IEnumerable<BuyList>> GetBuyLists();
        Task<IEnumerable<BuyList>> GetBuyListsDetails(int id);
    }
}
