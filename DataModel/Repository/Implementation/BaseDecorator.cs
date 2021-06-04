using DataModel.Entity.EntityContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Repository.Implementation
{
    /// <summary>
    /// Базовый класс декоратора
    /// </summary>
    public abstract class BaseDecorator : BaseRepository
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">DB context</param>
        public BaseDecorator(IDataBaseContext context)
            : base(context)
        {
        }
    }
}
