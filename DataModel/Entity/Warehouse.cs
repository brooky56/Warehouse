using DataModel.Entity.ManyToMany;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entity
{
    public class Warehouse : BaseEntity
    {

        public Warehouse()
        {

        }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Индекс
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Продукты склада 1-N connections
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Connection N-to-N WarehouseProducts
        /// </summary>
        public IEnumerable<WarehouseProduct> WarehouseProducts { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

    }
}
