using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Dictionary : BaseEntity
    {
        public Dictionary()
        {

        }

        public Dictionary(string[] info)
        {

            if (info != null && info.Length >= 4)
            {

                Word = info[0];
                WordLanguage = info[1];
                TranslatedWord = info[3];
                TranslatedLanguage = info[4];

            }

            else{throw new Exception("All values are required");}

        }

        public string Word { get; set; }
        public string WordLanguage { get; set; }
        public string TranslatedWord { get; set; }
        public string TranslatedLanguage { get; set; }
    }
}
