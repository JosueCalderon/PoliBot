using System;
using System.Globalization;

namespace Entities_POJO
{
    public class Language : BaseEntity
    {
        public Language()
        {

        }

        public Language(string[] info)
        {

            if (info != null && info.Length >= 1)
            {

                Languages = info[0];
            }

            else

            {
                throw new Exception("All values are required[Languages]");

            }

        }

        public string Languages { get; set; }
        public string Populariry { get; set; }

    }
}
