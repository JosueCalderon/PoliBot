﻿using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
    public class AppMessagesCrudFactory : CrudFactory
    {
        AppMessageMapper _mapper;

        public AppMessagesCrudFactory()
        {
            _mapper = new AppMessageMapper();
            Dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstAppMessage = new List<T>();

            var lstResult = Dao.ExecuteQueryProcedure(_mapper.GetRetriveAllStatement());
            var dictionary = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAppMessage.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAppMessage;
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
