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
            var lstResult = Dao.ExecuteQueryProcedure(_mapper.GetRetriveStatement(entity));
            Dictionary<string, object> dic;
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = _mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var UsersList = new List<T>();

            var lstResult = Dao.ExecuteQueryProcedure(_mapper.GetRetriveAllStatement());
            if (lstResult.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResult);
                foreach (var c in objs) UsersList.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return UsersList;
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
