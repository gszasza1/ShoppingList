using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class FoodCounter
    {
        public int Id { get; set; }
        public int Counter { get; set; }
        public DateTime Modification { get; set; }
        public int FoodId { get; set; }
        public Food Foods { get; set; }
        public int BuyListId { get; set; }
        public BuyList BuyList { get; set; }
    }
}
