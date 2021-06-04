using DataModel.Entity.EntityContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataModel.Entity.EntitySeed
{
    public class ProductEntitySeed
    {
        /// <summary>
        /// Заполняет продукты
        /// </summary>
        /// <param name="dataBaseContext">The data base context.</param>
        /// <param name="owner">Сущность владельца продуктов</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static IEnumerable<Product> SeedProducts(IDataBaseContext dataBaseContext, User owner,
            IEnumerable<Warehouse> warehouses, int count = 5)
        {
            #region Массивы с возможными данными полей
            var productInfo = new
            {
                barcode = new string[]
                {
                    "10020301002",
                    "10232312322",
                    "83843093933"
                },
                description = new string[]
                {
                    "Candy",
                    "Fruits",
                    "Juice"
                },
                name = new string[]
                {
                    "Mars",
                    "Orange",
                    "Rich"
                }
            };


            #endregion

            var result = new List<Product>();

            Random random = new Random();

            for (var i = 0; i < count; i++)
            {
                var warehouseId = warehouses.ElementAtOrDefault(random.Next(0, warehouses.Count()))?.Id ?? Guid.Empty;

                var product = new Product
                {
                    Id = Guid.NewGuid(),
                    Amount = random.Next(0, 100),
                    Barcode = productInfo.barcode[random.Next(0, productInfo.barcode.Length)],
                    WarehouseId = warehouseId,
                    Name = productInfo.name[random.Next(0, productInfo.name.Length)],
                    CreatedByUser = owner,
                    CreatedBy = owner.Id,
                    CreatedOn = DateTime.Now
                };

                dataBaseContext.Products.Add(product);

                result.Add(product);
            }

            return result;
        }
    }
}
