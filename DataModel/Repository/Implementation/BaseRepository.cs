using DataModel.Entity;
using DataModel.Entity.EntityContext;
using Microsoft.EntityFrameworkCore;
using SequentialGuid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WarehouseTestAPI.Common;

namespace DataModel.Repository.Implementation
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    public class BaseRepository : IBaseRepository
    {
        /// <summary>
        /// Контекст подключения к БД
        /// </summary>
        public IDataBaseContext _DataBaseContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseRepository(IDataBaseContext dbContext)
        {
            _DataBaseContext = dbContext;
        }

        /// <summary>
        /// Создание экзеспляра сущности в базе данных
        /// </summary>
        /// <param name="createdEntity"></param>
        public Guid Create<T>(T createdEntity) where T : BaseEntity
        {
            if (createdEntity == null)
            {
                throw new ArgumentNullException(nameof(createdEntity), "Не получен объект создаваемой записи.");
            }
            //Добавлена установка последовательного гуида при создании
            createdEntity.Id = SequentialGuidGenerator.Instance.NewGuid();
            _DataBaseContext.Add(createdEntity);
            _DataBaseContext.SaveChanges();

            return createdEntity.Id;
        }

        public void Delete<T>(T deletedEntity) where T : BaseEntity
        {
            if (deletedEntity == null)
            {
                throw new ArgumentNullException(nameof(deletedEntity), "Не получен объект удаляемой записи.");
            }
            _DataBaseContext.Remove(deletedEntity);
            _DataBaseContext.SaveChanges();
        }

        /// <summary>
        /// Получение списка записей в базе данных по условию
        /// </summary>
        /// <param name="predicate"></param>
        public virtual async Task<List<T>> Find<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Не получен объект фильтра.");
            }

            var set = _DataBaseContext
                .Set<T>()
                .Where(predicate)
                .AsNoTracking();

            return await set.ToListAsync();
        }

        public virtual Task<List<T>> Find<T>(string sqlQuery) where T : BaseEntity
        {
            var set = _DataBaseContext
                .Set<T>()
                .FromSqlRaw(sqlQuery);

            return set.ToListAsync();
        }

        /// <summary>
        /// Получение списка записей в базе данных по запросу
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="specification"></param>
        public virtual async Task<List<T>> Find<T>(IQuerySpecification<T> specification) where T : BaseEntity
        {
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification), "Не получен объект запроса.");
            }

            var set = _DataBaseContext
                .Set<T>()
                .AsNoTracking()
                .AsQueryable();

            set = specification.Apply(set);

            return await set.ToListAsync();
        }


        /// <summary>
        /// Получение объекта по первичному ключу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetById<T>(Guid id) where T : BaseEntity
        {
            return await _DataBaseContext
               .Set<T>()
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Обновление экземпляра сущности в базе данных
        /// </summary>
        /// <param name="updatedEntity"></param>
        public virtual void Update<T>(T updatedEntity) where T : BaseEntity
        {
            if (updatedEntity == null)
            {
                throw new ArgumentNullException(nameof(updatedEntity), "Не получен объект обновляемой записи.");
            }
            _DataBaseContext.Update(updatedEntity);
            _DataBaseContext.SaveChanges();
        }
    }
}
