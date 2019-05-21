using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Range(1, 10, ErrorMessage = "Unit price must be betwwen 1 and 10")]
        public int Stars { get; set; }
        public FoodMessageRating FoodMessageRating { get; set; }
    }
}
