using DataModel.Entity;
using DataModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseTestAPI.ViewModels;
using WarehouseTestAPI.ViewModels.Common;

namespace WarehouseTestAPI.Services.Implementation
{
    public class UserService : IBaseService<User, UserView>
    {
        /// <summary>
        /// Репозиторий пользователей
        /// </summary>
        private readonly IBaseRepository _Repository;

        /// <summary>
        /// Инициализация экземпляра класса <see cref="UserService"/>.
        /// </summary>
        /// <param name="userRepository">Репозиторий пользователей.</param>
        /// <exception cref="ArgumentNullException">userRepository</exception>
        public UserService(IBaseRepository repository)
        {
            _Repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public EntityReference Create(UserView view)
        {
            var user = MapToEntity(view);

            user.Id = _Repository.Create(user);

            return new EntityReference(user);
        }

        public void Delete(Guid entityId)
        {
            var user = _Repository.GetById<User>(entityId).Result;
            _Repository.Delete(user);
        }

        public UserView GetById(Guid entityId)
        {
            return MapToView(_Repository.GetById<User>(entityId).Result);
        }

        private UserView MapToView(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserView
            {
                Id = user.Id,

                Reference = user.ToEntityReference(),

                CreatedOn = user.CreatedOn,
                CreatedBy = user.CreatedBy,

                LastName = user.LastName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,

                Login = user.Login
            };
        }

        public User MapToEntity(UserView view)
        {
            if (view == null)
            {
                return null;
            }

            if (view.Id == Guid.Empty)
            {
                return new User
                {
                    Id = Guid.NewGuid(),
                    LastName = view.LastName,
                    FirstName = view.FirstName,
                    MiddleName = view.MiddleName,
                    Login = view.Login
                };
            }
            var original = _Repository.GetById<User>(view.Id).Result;
            original.LastName = view.LastName;
            original.FirstName = view.FirstName;
            original.MiddleName = view.MiddleName;

            return original;
        }

        public void Update(UserView view)
        {
            var updUser = MapToEntity(view);
            _Repository.Update(updUser);
        }
    }
}
