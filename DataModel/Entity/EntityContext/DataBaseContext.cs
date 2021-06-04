using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataModel.Entity.EntityContext
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        /// <summary>
        /// Триггер создания модели 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetConfiguration();
        }

        public override int SaveChanges()
        {
            var changedData = ChangeTracker.Entries()
                .Where(m => m?.Entity != null)
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in changedData)
            {
                if (entry.Entity is BaseEntity en)
                {
                    if (entry.State == EntityState.Added)
                    {
                        en.CreatedOn = DateTime.Now;
                    }
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
