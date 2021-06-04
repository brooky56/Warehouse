using DataModel.Entity.EntityContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entity.EntitySeed
{
    public class UserEntitySeed
    {
        /// <summary>
        /// Заполнение User (Admin)
        /// </summary>
        /// <param name="dataBaseContext">The data base context.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Admin User
        /// </returns>
        public static User SeedAdministrator(DataBaseContext dataBaseContext)
        {
            var newGuid = Guid.NewGuid();
            var sysAdmin = new User
            {
                Id = newGuid,
                FirstName = "System",
                LastName = "Administrator",
                Login = "admin",
                CreatedBy = newGuid
            };


            dataBaseContext.Users.Add(sysAdmin);

            return sysAdmin;
        }
    }
}
