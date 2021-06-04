using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entity.EntityContext
{
    /// <summary>
    /// Интерфейс конфигурации сущностей
    /// </summary>
    public interface IDataConfiguration
    {
        /// <summary>
        /// Конфигурация сущностей
        /// </summary>
        /// <param name="modelBuilder">Model API builder instance</param>
        void ConfigureData(ModelBuilder modelBuilder);
    }
}
