using System;
using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreApi
{
    public class UserManager : BaseManager
    {

        private UserCrudFactory crudUser;

        public UserManager()
        {
            crudUser = new UserCrudFactory();
        }

        public void Create(User user)
        {
            try
            {
                var u = crudUser.Retrieve<User>(user);

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
            return crudUser.RetrieveAll<User>();
        }

        public User RetrieveById(User user)
        {
            User c = null;
            try
            {
                c = crudUser.Retrieve<User>(user);
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
            crudUser.Update(user);
        }

        public void Delete(User user)
        {
            crudUser.Delete(user);
        }

    }
}
