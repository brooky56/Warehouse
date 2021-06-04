using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entity.EntityContext.DataConfiguration
{
    /// <summary>
    /// Класс для иницилизации нчальных настроек конфигурация сущности Warehouse 
    /// </summary>
    public class WarehouseEntityConfiguration : IDataConfiguration
    {
        public void ConfigureData(ModelBuilder modelBuilder)
        {
            #region Warehouse Entity Configuration

            modelBuilder.Entity<Warehouse>().HasKey(a => a.Id);

            modelBuilder.Entity<Warehouse>().Property(a => a.Name)
                .HasMaxLength(250);
            modelBuilder.Entity<Warehouse>().Property(a => a.Country)
                .HasMaxLength(50);
            modelBuilder.Entity<Warehouse>().Property(a => a.City)
                .HasMaxLength(50);
            modelBuilder.Entity<Warehouse>().Property(a => a.PostalCode)
                .HasMaxLength(250);
            modelBuilder.Entity<Warehouse>().Property(a => a.Street)
                .HasMaxLength(250);
            modelBuilder.Entity<Warehouse>().Property(a => a.Name)
                .HasMaxLength(250);
            modelBuilder.Entity<Warehouse>().Property(a => a.Phone)
                .HasMaxLength(50);
            modelBuilder.Entity<Warehouse>().Property(a => a.Description)
                .HasMaxLength(2000);


            modelBuilder.Entity<Warehouse>().Property(a => a.CreatedOn)
                .HasDefaultValueSql("current_timestamp");

            //Внешние ключи
            modelBuilder.Entity<Warehouse>()
                .HasMany(a => a.Products)
                .WithOne(c => c.Warehouse);

            #endregion
        }
    }
}
