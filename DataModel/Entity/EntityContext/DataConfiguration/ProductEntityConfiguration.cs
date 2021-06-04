using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entity.EntityContext.DataConfiguration
{
    /// <summary>
    /// Класс для иницилизации нчальных настроек конфигурация сущности Product 
    /// </summary>
    public class ProductEntityConfiguration : IDataConfiguration
    {
        public void ConfigureData(ModelBuilder modelBuilder)
        {
            #region Contact Entity Configuration
            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            modelBuilder.Entity<Product>().Property(p => p.Description)
                .HasMaxLength(2000);

            modelBuilder.Entity<Product>().Property(p => p.Barcode)
                .HasMaxLength(100);


            modelBuilder.Entity<Product>().Property(c => c.CreatedOn)
                .HasDefaultValueSql("current_timestamp");

            //Внешние ключи
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Warehouse)
                .WithMany(a => a.Products);
            #endregion
        }
    }
}
