using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class Messages
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FoodId is required.", AllowEmptyStrings = false)]
        public int FoodId { get; set; }
        public Food Foods { get; set; }

        [StringLength(1000, ErrorMessage = "Name length fault.")]
        public string Text { get; set; }

        [Range(1, 10, ErrorMessage = "Unit price must be betwwen 1 and 10")]
        public int Rating { get; set; }

        public DateTime creation { get; set; }
    }
}
