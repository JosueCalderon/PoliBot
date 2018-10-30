using System;

namespace Entities_POJO
{
    public class Translation : BaseEntity
    {
        public Translation()
        {
        }

        public Translation(string[] info)
        {
            if (info != null && info.Length >= 6)
            {
                User = info[0];
                if (DateTime.TryParse(info[1], out var date))
                    Date = date;
                else
                    throw new Exception("Date must be a date");
                Language = info[2];
                SpanishSentence = info[3];
                TranslatedSentence = info[4];
                Popularity = 0;
            }
            else
            {
                throw new Exception("All values are required");
            }

        }

        public string User { get; set; }
        public DateTime Date { get; set; }
        public string Language { get; set; }
        public string SpanishSentence { get; set; }
        public string TranslatedSentence { get; set; }
        public int Popularity { get; set; }

    }
}
