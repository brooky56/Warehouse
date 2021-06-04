using DataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseTestAPI.ViewModels.Common
{
    /// <summary>
    /// Ссылка на сущность
    /// </summary>
    public class EntityReference
    {
        /// <summary>
        /// Имя сущности
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Отображаемое имя сущности
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="EntityReference"/>.
        /// </summary>
        public EntityReference()
        {
            EntityName = String.Empty;
            Name = String.Empty;
            Id = Guid.Empty;
        }

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="EntityReference"/>.
        /// </summary>
        /// <param name="entityName">Им сущности.</param>
        /// <param name="name">Отображаемое имя.</param>
        /// <param name="id">Идентификатор сущности.</param>
        public EntityReference(string entityName, string name, Guid id)
        {
            EntityName = entityName;
            Name = name;
            Id = id;
        }

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="EntityReference"/>.
        /// </summary>
        /// <param name="entity">Данные сущности.</param>
        public EntityReference(BaseEntity entity)
        {
            if (entity != null)
            {
                EntityName = entity.GetType().Name;
                Name = entity.Name;
                Id = entity.Id;
            }
        }
    }
}
