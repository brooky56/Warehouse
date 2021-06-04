using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WarehouseTestAPI.ViewModels.Common;

namespace WarehouseTestAPI.ViewModels
{
    public class WarehouseView : BaseView
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [StringLength(250, ErrorMessage = "{0} length can't be more than {1}")]
        public string Name { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [Required]
        [Phone]
        public string Phone { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "{0} length can't be more than {1}")]
        public string Country { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "{0} length can't be more than {1}")]
        public string City { get; set; }

        /// <summary>
        /// Индекс
        /// </summary>
        [Required]
        [StringLength(250, ErrorMessage = "{0} length can't be more than {1}")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        [Required]
        [StringLength(250, ErrorMessage = "{0} length can't be more than {1}")]
        public string Street { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [StringLength(2000, ErrorMessage = "{0} length can't be more than {1}")]
        public string Description { get; set; }
    }
}
