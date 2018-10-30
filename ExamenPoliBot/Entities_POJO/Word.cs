using System;

namespace Entities_POJO
{
    public class Word : BaseEntity
    {

        public Word()
        {

        }

        public Word(string[] info)
        {

            if (info != null && info.Length >= 3)
            {

                Words = info[0];
                Language = info[1];
                TranslationQuantity = 0;

            }
            else
            {
                throw new Exception("All values are require [Word,Language,TranslationQuantity]");
            }
        }

        public string Words { get; set; }
        public string Language {get; set; }
        public int TranslationQuantity { get; set; }
    }
}

