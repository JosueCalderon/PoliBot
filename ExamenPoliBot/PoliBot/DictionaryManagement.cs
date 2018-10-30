using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Entities_POJO;

namespace PoliBot
{
    public class DictionaryManagement
    {

        private readonly DictionaryCrudFactory _crudDictionary;

        public DictionaryManagement()
        {
            _crudDictionary = new DictionaryCrudFactory();
        }

        public void Create(Dictionary dictionary)
        {
            _crudDictionary.Create(dictionary);
        }


        public List<Dictionary> RetrieveAll()
        {
            return _crudDictionary.RetrieveAll<Dictionary>();
        }

        public Dictionary RetrieveById(Dictionary dictionary)
        {
            return _crudDictionary.Retrieve<Dictionary>(dictionary);
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

