using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Entities_POJO;

namespace PoliBot
{
    public class WordManagement
    {
        private readonly WordCrudFactory _crudWord;

        public WordManagement()
        {
            _crudWord = new WordCrudFactory();
        }

        public void Create(Word word)
        {
            _crudWord.Create(word);
        }


        public List<Word> RetrieveAll()
        {
            return _crudWord.RetrieveAll<Word>();
        }

        public Word RetrieveById(Word word)
        {
            return _crudWord.Retrieve<Word>(word);
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
