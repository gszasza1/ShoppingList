using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class FridgeList
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<FoodCounter> shoppingList { get; } = new List<FoodCounter>();

    }
}
