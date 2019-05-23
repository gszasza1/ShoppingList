using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class Food
    {
        public int Id { get; set; }
        [StringLength(200, ErrorMessage = "Name length fault.")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Unit price must be higher than 0.")]
        public int UnitPrice { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public Categorys Category { get; set; }

        
        public byte[] RowVersion { get; set; }
    }

    public enum Categorys
    {
        Drink=1,
        Meal=2,
        Sweets=4,
        Others=8

    }
}
