using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
   public class TranslationCrudFactory : CrudFactory
    {

        private readonly TranslationMapper _mapper;

        public TranslationCrudFactory()
        {
            _mapper = new TranslationMapper();
            Dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var translation = (Translation)entity;
            var sqlOperation = _mapper.GetCreateStatement(translation);
            Dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var TranslationsList = new List<T>();

            var lstResult = Dao.ExecuteQueryProcedure(_mapper.GetRetriveAllStatement());
            if (lstResult.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResult);
                foreach (var c in objs) TranslationsList.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return TranslationsList;
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
