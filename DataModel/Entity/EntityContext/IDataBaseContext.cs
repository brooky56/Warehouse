using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataModel.Entity.EntityContext
{
    public interface IDataBaseContext
    {
        /// <summary>
        /// Список складов в БД
        /// </summary>
        DbSet<Warehouse> Warehouses { get; set; }

        /// <summary>
        /// Список пользователей в БД
        /// </summary>
        DbSet<User> Users { get; set; }

        /// <summary>
        /// Список продуктов в БД
        /// </summary>
        DbSet<Product> Products { get; set; }

        /// <summary>
        /// Sets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// Добавить новый объект
        /// </summary>
        /// <param name="entry">Объект.</param>
        /// <returns></returns>
        EntityEntry Add(object entry);

        /// <summary>
        /// Обновить существующий объект
        /// </summary>
        /// <param name="entry">Объект.</param>
        /// <returns></returns>
        EntityEntry Update(object entry);

        /// <summary>
        /// Удалить существующий объект
        /// </summary>
        /// <param name="entry">Объект.</param>
        /// <returns></returns>
        EntityEntry Remove(object entry);

        /// <summary>
        ///Сохранить изменения модели
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        DatabaseFacade Database { get; }
    }
}
