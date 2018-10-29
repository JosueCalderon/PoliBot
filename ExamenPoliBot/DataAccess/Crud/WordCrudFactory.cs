using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
    public class WordCrudFactory : CrudFactory
    {

        private readonly WordMapper _mapper;

        public WordCrudFactory()
        {
            _mapper = new WordMapper();
            Dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var word = (Word)entity;
            var sqlOperation = _mapper.GetCreateStatement(word);
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
            var wordsList = new List<T>();

            var lstResult = Dao.ExecuteQueryProcedure(_mapper.GetRetriveAllStatement());
            if (lstResult.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResult);
                foreach (var c in objs) wordsList.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return wordsList;
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
