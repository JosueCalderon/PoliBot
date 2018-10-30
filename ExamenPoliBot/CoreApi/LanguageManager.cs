using System;
using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreApi
{
    public class LanguageManager : BaseManager
    {

        private LanguageCrudFactory crudLanguage;

        public LanguageManager()
        {
            crudLanguage = new LanguageCrudFactory();
        }

        public void Create(Language language)
        {
            try
            {
                var u = crudLanguage.Retrieve<Language>(language);

                if (u != null)
                {
                    //Language already exist
                    throw new BusinessException(3);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Language> RetrieveAll()
        {
            return crudLanguage.RetrieveAll<Language>();
        }

        public Language RetrieveById(Language language)
        {
            throw new NotImplementedException();
        }

        public void Update(Language language)
        {
            throw new NotImplementedException();
        }

        public void Delete(Language language)
        {
            throw new NotImplementedException();
        }
    }
}
