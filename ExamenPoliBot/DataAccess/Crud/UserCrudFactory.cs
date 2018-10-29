using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
    public class UserCrudFactory : CrudFactory
    {

        private readonly UserMapper _mapper;

        public UserCrudFactory()
        {
            _mapper = new UserMapper();
            Dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var customer = (User)entity;
            var sqlOperation = _mapper.GetCreateStatement(customer);
            Dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
