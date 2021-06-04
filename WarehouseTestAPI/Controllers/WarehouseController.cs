using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WarehouseTestAPI.Services;
using WarehouseTestAPI.ViewModels;
using WarehouseTestAPI.ViewModels.Common;

namespace WarehouseTestAPI.Controllers
{
    /// <summary>
    /// Контроллер склада
    /// </summary>

    [Produces("application/json")]
    [Route("api/warehouses")]
    public class WarehouseController
    {
        /// <summary>
        /// Репозиторий склада
        /// </summary>
        IWarehouseService _WarehouseService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public WarehouseController(IWarehouseService warehouseService)
        {
            _WarehouseService = warehouseService;

        }

        [HttpGet("{id}")]
        public WarehouseView Get(Guid id)
        {
            return _WarehouseService.GetById(id);
        }

        [HttpPost]
        public EntityReference Post([FromBody] WarehouseView value)
        {
            return _WarehouseService.Create(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WarehouseView value)
        {
            _WarehouseService.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _WarehouseService.Delete(id);
        }


        [HttpGet]
        [Route("getbyproduct")]
        public IEnumerable<WarehouseView> GetByProductId(Guid productId)
        {
            return _WarehouseService.GetByProductId(productId);
        }

    }
}
