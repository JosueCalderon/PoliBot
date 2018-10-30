using System;
using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreApi
{
    public class DictionaryManager : BaseManager
    {
        private DictionaryCrudFactory _crudDictionary;

        public DictionaryManager()
        {
            _crudDictionary = new DictionaryCrudFactory();
        }

        public void Create(Dictionary dictionary)
        {
            try
            {
                var d = _crudDictionary.Retrieve<Dictionary>(dictionary);

                if (d != null)
                {
                    //Dictionary already exist
                    throw new BusinessException(7);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Dictionary> RetrieveAll()
        {
            return _crudDictionary.RetrieveAll<Dictionary>();
        }

        public Dictionary RetrieveById(Dictionary dictionary)
        {
            Dictionary d = null;
            try
            {
                d = _crudDictionary.Retrieve<Dictionary>(dictionary);
                if (d == null)
                {
                    throw new BusinessException(8);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return d;
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
