using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Entities_POJO;

namespace PoliBot
{
    public class TranslationManagement
    {
        private readonly TranslationCrudFactory _crudTranslation;

        public TranslationManagement()
        {
            _crudTranslation = new TranslationCrudFactory();
        }

        public void Create(Translation translation)
        {
            _crudTranslation.Create(translation);
        }


        public List<Translation> RetrieveAll()
        {
            return _crudTranslation.RetrieveAll<Translation>();
        }

        public Translation RetrieveById(Translation translation)
        {
            return _crudTranslation.Retrieve<Translation>(translation);
        }

        internal void Update(Dictionary dictionary)
        {
            throw new NotImplementedException();
        }

        public void Delete(Dictionary dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
