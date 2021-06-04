using DataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseTestAPI.Common;

namespace DataModel.Repository
{
    /// <summary>
    /// Интерфейс базового репозитория
    /// </summary>
    public interface IBaseRepository
    {
        /// <summary>
        /// Создание записи
        /// </summary>
        /// <param name="createdEntity"></param>
        Guid Create<T>(T createdEntity) where T : BaseEntity;

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="deletedEntity"></param>
        void Delete<T>(T deletedEntity) where T : BaseEntity;

        /// <summary>
        /// Обновление записи 
        /// </summary>
        /// <param name="updatedEntity"></param>
        void Update<T>(T updatedEntity) where T : BaseEntity;

        /// <summary>
        /// Получает запись по первичному ключу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById<T>(Guid id) where T : BaseEntity;

        /// <summary>
        /// Получение списка сущностей по условию
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">Условие</param>
        /// <returns></returns>
        Task<List<T>> Find<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        /// <summary>
        /// Получение списка сущностей по запросу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="spec"></param>
        /// <returns></returns>
        Task<List<T>> Find<T>(IQuerySpecification<T> spec) where T : BaseEntity;

        Task<List<T>> Find<T>(string sqlQuery) where T : BaseEntity;
    }
}
