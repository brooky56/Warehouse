using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseTestAPI.ViewModels
{
    /// <summary>
    /// Представление пользователя
    /// </summary>
    public class UserView : BaseView
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

    }
}
