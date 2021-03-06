﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class Messages
    {
        public int Id { get; set; }
        [StringLength(1000, ErrorMessage = "Name length fault.")]
        public string Text { get; set; }

        public FoodMessageRating FoodMessageRating { get; set; }
    }
}
