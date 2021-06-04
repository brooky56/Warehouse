using DataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseTestAPI.ViewModels;

namespace WarehouseTestAPI.Services
{
    public interface IWarehouseService : IBaseService<Warehouse, WarehouseView>
    {

        /// <summary>
        /// Получение сущностей по Продукту
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="isOrderDescending"></param>
        /// <returns></returns>
        IEnumerable<WarehouseView> GetByProductId(Guid productId, bool isOrderDescending = false);
    }
}
