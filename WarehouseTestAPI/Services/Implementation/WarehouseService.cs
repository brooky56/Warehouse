using DataModel.Entity;
using DataModel.Entity.ManyToMany;
using DataModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseTestAPI.Common;
using WarehouseTestAPI.ViewModels;
using WarehouseTestAPI.ViewModels.Common;

namespace WarehouseTestAPI.Services.Implementation
{
    public class WarehouseService : IWarehouseService
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="warehouseService"/>.
        /// </summary>
        public WarehouseService(IBaseRepository repository)
        {
            _Repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Репозиторий склада
        /// </summary>
        private readonly IBaseRepository _Repository;

        public EntityReference Create(WarehouseView view)
        {
            var warehouse = MapToEntity(view);
            warehouse.Id = _Repository.Create(warehouse);

            return new EntityReference(warehouse);
        }

        public void Delete(Guid id)
        {
            var deletedEntity = _Repository.GetById<Warehouse>(id).Result;
            _Repository.Delete(deletedEntity);
        }

        public IEnumerable<WarehouseView> GetByProductId(Guid productId, bool isOrderDescending = false)
        {
            var queryWarehouse = new AllTemsQuerySpecification<Warehouse> { DescOrder = isOrderDescending, Top = 100 };
            IEnumerable<Warehouse> warehouses = _Repository.Find(queryWarehouse).Result;
            IEnumerable<WarehouseProduct> warehousesProducts = _Repository.Find<WarehouseProduct>(w => w.ProductId == productId).Result;

            var query = warehouses.Join(warehousesProducts,
                w => w.Id,
                wp => wp.WarehouseId,
                (w, wp) => new Warehouse()
                {
                    Id = w.Id,
                    Name = w.Name,
                    Phone = w.Phone,
                    Country = w.Country,
                    City = w.City,
                    PostalCode = w.PostalCode,
                    Street = w.Street,
                    CreatedBy = w.CreatedBy,
                    CreatedOn = w.CreatedOn

                });

            return query.Select(MapToView).ToList();
        }

        public WarehouseView GetById(Guid id)
        {
            return MapToView(_Repository.GetById<Warehouse>(id).Result);
        }

        private WarehouseView MapToView(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                return null;
            }

            return new WarehouseView
            {
                Id = warehouse.Id,

                CreatedOn = warehouse.CreatedOn,
                CreatedBy = warehouse.CreatedBy,

                Name = warehouse.Name,
                Phone = warehouse.Phone,
                Country = warehouse.Country,
                City = warehouse.City,
                PostalCode = warehouse.PostalCode,
                Street = warehouse.Street,
                Description = warehouse.Description,

                Reference = warehouse.ToEntityReference(),

            };
        }

        public Warehouse MapToEntity(WarehouseView view)
        {
            if (view == null)
            {
                return null;
            }

            if (view.Id == Guid.Empty)
            {
                return new Warehouse
                {
                    Id = Guid.NewGuid(),
                    Name = view.Name,
                    Phone = view.Phone,
                    Country = view.Country,
                    City = view.City,
                    PostalCode = view.PostalCode,
                    Street = view.Street,

                    Description = view.Description
                };
            }

            var original = _Repository.GetById<Warehouse>(view.Id).Result;

            original.Name = view.Name;
            original.Phone = view.Phone;
            original.Country = view.Country;
            original.City = view.City;
            original.PostalCode = view.PostalCode;
            original.Street = view.Street;
            original.Description = view.Description;

            return original;
        }

        public void Update(WarehouseView view)
        {
            _Repository.Update(MapToEntity(view));
        }
    }
}
