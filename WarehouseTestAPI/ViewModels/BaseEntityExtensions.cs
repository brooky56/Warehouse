using WarehouseTestAPI.ViewModels.Common;

namespace DataModel.Entity
{
    public static class BaseEntityExtensions
    {
        /// <summary>
        /// Возвращает ссылку на сущность из сущности
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static EntityReference ToEntityReference(this BaseEntity entity)
        {
            return new EntityReference(entity);
        }
    }
}
