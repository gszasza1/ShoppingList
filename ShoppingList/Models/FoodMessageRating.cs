using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class FoodMessageRating
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FoodId is required.", AllowEmptyStrings = false)]
        public int FoodId { get; set; }
        public Food Foods { get; set; }

        public DateTime Creation { get; set; }

        public  Rating Rating { get; set; }
        
        public  Messages Messages { get; set; }
    }
}
