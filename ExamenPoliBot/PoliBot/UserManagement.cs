using System;
using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;

namespace PoliBot
{
    public class UserManagement
    {
        private readonly UserCrudFactory _crudUser;

        public UserManagement()
        {
            _crudUser = new UserCrudFactory();
        }

        public void Create(User user)
        {
            _crudUser.Create(user);
        }


        public List<User> RetrieveAll()
        {
            return _crudUser.RetrieveAll<User>();
        }

        public User RetrieveById(User user)
        {
            return _crudUser.Retrieve<User>(user);
        }

        internal void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }
    }
}
