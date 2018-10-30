using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Entities_POJO;

namespace PoliBot
{
    public class LanguageManagement
    {
        private readonly LanguageCrudFactory _crudLanguage;

        public LanguageManagement()
        {
            _crudLanguage = new LanguageCrudFactory();
        }

        public void Create(Language language)
        {
            _crudLanguage.Create(language);
        }


        public List<Language> RetrieveAll()
        {
            return _crudLanguage.RetrieveAll<Language>();
        }

        public Language RetrieveById(Language language)
        {
            return _crudLanguage.Retrieve<Language>(language);
        }

        internal void Update(Language language)
        {
            throw new NotImplementedException();
        }

        public void Delete(Language language)
        {
            throw new NotImplementedException();
        }
    }
}
