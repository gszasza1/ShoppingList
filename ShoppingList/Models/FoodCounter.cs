using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class FoodCounter
    {
        public int Id { get; set; }
        public int Counter { get; set; }
        public DateTime Modification { get; set; }

        [Required(ErrorMessage = "FoodId is required.")]
        public int FoodId { get; set; }
        public Food Foods { get; set; }

        [Required(ErrorMessage = "BuyListId is required.")]
        public int BuyListId { get; set; }
        public BuyList BuyList { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
