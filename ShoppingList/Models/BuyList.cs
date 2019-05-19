using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class BuyList
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Creator { get; set; }
        public ICollection<FoodCounter> shoppingList { get; } = new List<FoodCounter>();

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
