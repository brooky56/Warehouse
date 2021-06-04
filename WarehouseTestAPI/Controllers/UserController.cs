using DataModel.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseTestAPI.Services;
using WarehouseTestAPI.Services.Implementation;
using WarehouseTestAPI.ViewModels;
using WarehouseTestAPI.ViewModels.Common;

namespace WarehouseTestAPI.Controllers
{
    /// <summary>
    /// Контроллер пользователей
    /// </summary>
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        /// <summary>
        /// Репозиторий пользователей
        /// </summary>
        readonly UserService _UserService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserController(IBaseService<User, UserView> userService)
        {
            _UserService = (UserService)userService;
        }

        [HttpPost]
        public EntityReference Post([FromBody] UserView value)
        {
            return _UserService.Create(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserView value)
        {
            _UserService.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _UserService.Delete(id);
        }
    }
}
