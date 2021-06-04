using DataModel.Entity.ManyToMany;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entity
{
    public class Product : BaseEntity
    {
        public Product()
        {

        }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Штрих-код товара
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Connection N-to-N WarehouseProducts
        /// </summary>
        public IEnumerable<WarehouseProduct> WarehouseProducts { get; set; }

        /// <summary>
        /// Склад
        /// </summary>
        public Warehouse Warehouse { get; set; }

        /// <summary>
        /// Уникальный идентификатор склада
        /// </summary>
        public Guid WarehouseId { get; set; }
    }
}
