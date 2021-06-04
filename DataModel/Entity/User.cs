using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entity
{
    public class User : BaseEntity
    {
        public User()
        {

        }

        /// <summary>
        /// Отображаемое имя.
        /// </summary>
        public override string Name => $"{LastName} {FirstName}";

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
