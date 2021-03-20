using AutoMapper;
using Domain.Entities;
using Infrastructure.CrossCutting.DTO;
using Infrastructure.CrossCutting.Models;
using Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class UserService
    {
        private readonly UserRepository repository;
        private readonly IMapper map;
        public UserService(UserRepository _repository, IMapper _map)
        {
            repository = _repository;
            map = _map;
        }

        public User Get(int Id, bool sensitive = true)
        {
            var user = repository.Select(Id);
            user.Password = sensitive ? user.Password = string.Empty : user.Password;
            return map.Map<User>(user);
        }
        public User GetByLogin(string login, bool sensitive = true)
        {
            var user = repository.SelectBy(login);
            user.Password = sensitive ? user.Password = string.Empty : user.Password;
            return map.Map<User>(user);
        }

        public IList<User> GetAll(bool sensitive = true)
        {
            if (sensitive)
            {
                var userArray = repository.Select().ToArray();
                Array.ForEach(userArray, x => x.Password = string.Empty);
                return map.Map<IList<User>>(userArray.ToList());
            }
            else
            {
                return map.Map<IList<User>>(repository.Select());
            }
        }

        public User Post(User user)
        {
            return map.Map<User>(repository.Insert(map.Map<UserEntity>(user)));

        }

        public bool ValidateUser(AuthUser user)
        {
            var userData = repository.SelectBy(user.Login);

            if (userData != null)
            {
                if (userData.Password == user.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
