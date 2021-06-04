using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseTestAPI.ViewModels.Common;

namespace WarehouseTestAPI.ViewModels
{
    public class BaseView
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Текущая сущность в виде ссылки
        /// </summary>
        public EntityReference Reference { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Id создателя записи
        /// </summary>
        public Guid CreatedBy { get; set; }
    }
}
