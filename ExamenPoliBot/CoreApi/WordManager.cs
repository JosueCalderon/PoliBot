using System;
using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreApi
{
    public class WordManager : BaseManager
    {

        private WordCrudFactory crudWord;

        public WordManager()
        {
            crudWord = new WordCrudFactory();
        }

        public void Create(Word word)
        {
            try
            {
                var u = crudWord.Retrieve<Word>(word);

                if (u != null)
                {
                    //Word already exist
                    throw new BusinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Word> RetrieveAll()
        {
            return crudWord.RetrieveAll<Word>();
        }

        public Word RetrieveById(Word word)
        {
            Word w = null;
            try
            {
                w = crudWord.Retrieve<Word>(word);
                if (w == null)
                {
                    throw new BusinessException(5);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return w;
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
