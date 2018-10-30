using System;
using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreApi
{
    public class TranslationManager : BaseManager
    {

        private TranslationCrudFactory _crudTranslation;

        public TranslationManager()
        {
            _crudTranslation = new TranslationCrudFactory();
        }

        public void Create(Translation translation)
        {
            try
            {
                var t = _crudTranslation.Retrieve<Translation>(translation);

                if (t != null)
                {
                    //translation already exist
                    throw new BusinessException(6);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Translation> RetrieveAll()
        {
            return _crudTranslation.RetrieveAll<Translation>();
        }

        public Translation RetrieveById(Translation translation)
        {
            throw new NotImplementedException();
        }

        public void Update(Translation translation)
        {
            throw new NotImplementedException();
        }

        public void Delete(Translation translation)
        {
            throw new NotImplementedException();
        }
    }
}
