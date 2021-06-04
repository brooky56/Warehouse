using System;

namespace DataModel.Entity.ManyToMany
{
    // <summary>
    /// Таблица связей N-to-N для Склад и Продукт
    /// </summary>
    public class WarehouseProduct : BaseEntity
    {
        /// <summary>
        /// Склад
        /// </summary>
        public Warehouse Warehouse { get; set; }

        /// <summary>
        /// Продукт
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Индефикатор Склада
        /// </summary>
        public Guid WarehouseId { get; set; }

        /// <summary>
        /// Индефикатор Продукта
        /// </summary>
        public Guid ProductId { get; set; }
    }
}
