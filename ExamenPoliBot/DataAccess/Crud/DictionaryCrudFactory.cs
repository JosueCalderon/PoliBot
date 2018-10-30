using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
    public class DictionaryCrudFactory : CrudFactory
    {
        private readonly DictionaryMapper _mapper;

        public DictionaryCrudFactory()
        {
            _mapper = new DictionaryMapper();
            Dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var language = (Dictionary)entity;
            var sqlOperation = _mapper.GetCreateStatement(language);
            Dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = Dao.ExecuteQueryProcedure(_mapper.GetRetriveStatement(entity));
            if (lstResult.Count <= 0)
                return default(T);
            var dic = lstResult[0];
            var obj = _mapper.BuildObject(dic);
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        public List<T> RetrieveListByName<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var DictionariesList = new List<T>();

            var lstResult = Dao.ExecuteQueryProcedure(_mapper.GetRetriveAllStatement());
            if (lstResult.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResult);
                foreach (var c in objs) DictionariesList.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return DictionariesList;
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

