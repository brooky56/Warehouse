using DataModel.Entity.EntityContext;
using DataModel.Entity.EntitySeed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataModel
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Начальные данные
        /// </summary>
        /// <param name="dataBaseContext">The data base context.</param>
        public static void SeedMainData(this DataBaseContext dataBaseContext)
        {
            using var dbContextTransaction =
                dataBaseContext.Database.BeginTransaction(IsolationLevel.ReadUncommitted);

            try
            {
                if (!dataBaseContext.IsMainDataSeeded())
                {
                    var sysAdmin = UserEntitySeed.SeedAdministrator(dataBaseContext);
                    dataBaseContext.SaveChanges();

                    var warehouses = WarehouseEntitySeed.SeedWarehouses(dataBaseContext, sysAdmin);
                    dataBaseContext.SaveChanges();


                    ProductEntitySeed.SeedProducts(dataBaseContext, sysAdmin, warehouses);
                    dataBaseContext.SaveChanges();
                }

                dbContextTransaction.Commit();
            }
            catch (Exception e)
            {
                dbContextTransaction.Rollback();
                throw;
            }
        }


        /// <summary>
        /// Determines whether [is main data seeded].
        /// </summary>
        /// <param name="dataBaseContext">The data base context.</param>
        /// <returns>
        ///   <c>true</c> if [is main data seeded] [the specified data base context]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsMainDataSeeded(this IDataBaseContext dataBaseContext)
        {
            return dataBaseContext.Users.Any();
        }
    }
}
