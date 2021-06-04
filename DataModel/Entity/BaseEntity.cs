using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModel.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Отображаемое имя
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Возвращает имя сущности
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Id создателя записи
        /// </summary>
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// Пользователь создавший записи
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User CreatedByUser { get; set; }
    }
}
