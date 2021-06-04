using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entity.EntityContext.DataConfiguration
{
    /// <summary>
    /// Класс для иницилизации нчальных настроек конфигурация сущности User
    /// </summary>
    public class UserEntityConfiguration : IDataConfiguration
    {
        public void ConfigureData(ModelBuilder modelBuilder)
        {
            #region User Entity Configuration

            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<User>().Property(p => p.LastName)
                .HasMaxLength(250);
            modelBuilder.Entity<User>().Property(p => p.FirstName)
                .HasMaxLength(250);
            modelBuilder.Entity<User>().Property(p => p.MiddleName)
                .HasMaxLength(250);
            modelBuilder.Entity<User>().Property(p => p.Login)
                .HasMaxLength(50);

            modelBuilder.Entity<User>().Property(p => p.CreatedOn)
                .HasDefaultValueSql("current_timestamp");
            #endregion
        }
    }
}
