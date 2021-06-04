using DataModel.Entity;
using System;
using WarehouseTestAPI.ViewModels;
using WarehouseTestAPI.ViewModels.Common;

namespace WarehouseTestAPI.Services
{
    /// <summary>
    /// Базовый интерфейс сервиса представлений
    /// </summary>
    /// <typeparam name="TEntity">Сущность.</typeparam>
    /// <typeparam name="TView">Представление сущности.</typeparam>
    public interface IBaseService<TEntity, TView>
        where TEntity : BaseEntity
        where TView : BaseView
    {
        /// <summary>
        /// Вернуть представление по идентификатору
        /// </summary>
        /// <param name="entityId">Идентификатор сущности.</param>
        /// <returns></returns>
        TView GetById(Guid entityId);

        /// <summary>
        /// Создать по данным представления
        /// </summary>
        /// <param name="view">Данные представления.</param>
        EntityReference Create(TView view);

        /// <summary>
        /// Обновить по данным представления
        /// </summary>
        /// <param name="view">Данные представления.</param>
        void Update(TView view);

        /// <summary>
        /// Удалить по идентификатору
        /// </summary>
        /// <param name="entityId">Идентификатор сущности.</param>
        void Delete(Guid entityId);

        /// <summary>
        /// Маппинг представления к сущности по существующей сущности (обновление)
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        TEntity MapToEntity(TView view);
    }
}
