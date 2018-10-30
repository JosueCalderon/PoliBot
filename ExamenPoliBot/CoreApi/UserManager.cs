using System;
using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreApi
{
    public class UserManager : BaseManager
    {

        private UserCrudFactory _crudUser;

        public UserManager()
        {
            _crudUser = new UserCrudFactory();
        }

        public void Create(User user)
        {
            try
            {
                var u = _crudUser.Retrieve<User>(user);

                if (u != null)
                {
                    //User already exist
                    throw new BusinessException(2);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<User> RetrieveAll()
        {
            return _crudUser.RetrieveAll<User>();
        }

        public User RetrieveById(User user)
        {
            User c = null;
            try
            {
                c = _crudUser.Retrieve<User>(user);
                if (c == null)
                {
                    throw new BusinessException(1);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

    }
}
