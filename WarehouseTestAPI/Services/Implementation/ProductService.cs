using DataModel.Repository;
using System;

namespace WarehouseTestAPI.Services.Implementation
{
    public class ProductService : IProductService
    {
        public ProductService(IBaseRepository repository)
        {
            _Repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Репозиторий склада
        /// </summary>
        private readonly IBaseRepository _Repository;
    }
}
