using DataModel.Entity.ManyToMany;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entity.EntityContext.DataConfiguration
{
    public class WarehouseProductEntityConfiguration : IDataConfiguration
    {
        public void ConfigureData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WarehouseProduct>().Property(a => a.CreatedOn)
                .HasDefaultValueSql("current_timestamp");

            modelBuilder.Entity<WarehouseProduct>()
                .HasKey(ck => new { ck.WarehouseId, ck.ProductId });

            modelBuilder.Entity<WarehouseProduct>()
                .HasOne(p => p.Warehouse)
                .WithMany(ps => ps.WarehouseProducts)
                .HasForeignKey(fk => fk.WarehouseId);

            modelBuilder.Entity<WarehouseProduct>()
                .HasOne(p => p.Product)
                .WithMany(ps => ps.WarehouseProducts)
                .HasForeignKey(fk => fk.ProductId);

        }
    }
}
