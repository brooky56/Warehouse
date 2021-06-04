using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entity.EntityContext
{
    /// <summary>
    /// Интерфейс для заполнения сайта данными
    /// </summary>
    public interface IDataSeeding
    {
        /// <summary>
        /// Имя 
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Заполнение данными
        /// </summary>
        void Seed();

        /// <summary>
        /// Удаление данных
        /// </summary>
        void DeleteData();
    }
}
