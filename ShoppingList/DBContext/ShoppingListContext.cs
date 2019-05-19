using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public DbSet<BuyList> BuyList { get; set; }
        public DbSet<Messages> Messages { get; set; }
        private DateTime localtime = DateTime.Now;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

          
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries<Food>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
            foreach (var entry in ChangeTracker.Entries<FoodCounter>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues["Modification"] = localtime;
                        break;

                }
            }
            foreach (var entry in ChangeTracker.Entries<BuyList>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Food>().Property<bool>("IsDeleted");
            modelBuilder.Entity<BuyList>().Property<bool>("IsDeleted");

            modelBuilder.Entity<Food>().HasQueryFilter(post => EF.Property<bool>(post, "IsDeleted") == false);
            modelBuilder.Entity<BuyList>().HasQueryFilter(post => EF.Property<bool>(post, "IsDeleted") == false);

            modelBuilder.Entity<Food>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<FoodCounter>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<BuyList>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<FoodCounter>()
            .Property(b => b.Modification)
            .HasDefaultValue(localtime);

            modelBuilder.Entity<Food>()
            .Property(e => e.Category)
            .HasConversion<string>();

            modelBuilder.Entity<Food>()
                .Property(p => p.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            modelBuilder.Entity<BuyList>()
                .Property(p => p.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            modelBuilder.Entity<FoodCounter>()
                .Property(p => p.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();


        }


    }
}
