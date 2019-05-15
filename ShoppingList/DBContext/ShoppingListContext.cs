using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.DBContext
{
    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options)
            : base(options)
        { }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCounter> FoodCounters { get; set; }
        public DbSet<FridgeList> FridgeList { get; set; }
        public DbSet<BuyList> BuyList { get; set; }

    }
}
