using DataModel.Entity.EntityContext;
using System;
using System.Collections.Generic;

namespace DataModel.Entity.EntitySeed
{
    public class WarehouseEntitySeed
    {
        /// <summary>
        /// Заполняет спсиок складов
        /// </summary>
        /// <param name="dataBaseContext">The data base context.</param>
        /// <param name="owner">Ответсвенный за сущности</param>
        /// <returns></returns>
        public static IEnumerable<Warehouse> SeedWarehouses(IDataBaseContext dataBaseContext, User owner)
        {
            #region Данные организаций
            var warehouses = new[] {
                new {
                    name = "Warehouse1",
                    country = "Россия",
                    city = "Москва",
                    phone = "487-896-6087",
                    postalCode = "4780-320",
                    street = "Ленинградская, 12",
                },
                new {
                    name = "Warehouse2",
                    country = "Россия",
                    city = "Иннополис",
                    phone = "882-119-8413",
                    postalCode = "4780-320",
                    street = "Пушкинская, 12Б",
                },
                new {
                    name = "Warehouse3",
                    country = "Россия",
                    city = "Москва",
                    phone = "670-410-9660",
                    postalCode = "5029",
                    street = "Декабристов, 12 ",
                }
            };
            #endregion



            var result = new List<Warehouse>();

            foreach (var warehouse in warehouses)
            {
                var warehouseEntity = new Warehouse
                {
                    Id = Guid.NewGuid(),
                    Name = warehouse.name,
                    Phone = warehouse.phone,
                    Country = warehouse.country,
                    PostalCode = warehouse.postalCode,
                    City = warehouse.city,
                    Street = warehouse.street,
                    CreatedBy = owner.Id
                };

                dataBaseContext.Warehouses.Add(warehouseEntity);

                result.Add(warehouseEntity);
            }

            return result;
        }
    }
}
