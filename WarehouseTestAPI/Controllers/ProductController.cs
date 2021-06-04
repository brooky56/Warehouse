using Microsoft.AspNetCore.Mvc;
using WarehouseTestAPI.Services;

namespace WarehouseTestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/contacts")]
    public class ProductController : Controller
    {
        /// <summary>
        /// Репозиторий продуктов
        /// </summary>
        IProductService _ProductService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductController(IProductService productService)
        {
            _ProductService = productService;
        }
 
    }
}
