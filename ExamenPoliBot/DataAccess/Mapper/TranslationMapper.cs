using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class TranslationMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DbColUser = "USER";
        private const string DbColDate = "DATE";
        private const string DbColLanguage = "LANGUAGE";
        private const string DbColSpanishSentence = "SPANISH_SENTENCE";
        private const string DbColTranslatedSentence = "TRANSLATED_SENTENCE";
        private const string DbColPopularity = "POPULARITY";

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var translation = BuildObject(row);
                lstResults.Add(translation);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var translation = new Translation
            {
                User = GetStringValue(row, DbColUser),
                Date = GetDateTimeValue(row, DbColDate),
                Language = GetStringValue(row, DbColLanguage),
                SpanishSentence = GetStringValue(row, DbColSpanishSentence),
                TranslatedSentence = GetStringValue(row, DbColTranslatedSentence),
                Popularity = GetIntValue(row, DbColPopularity)

            };

            return translation;
        }


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_TRANSLATION_PR" };

            var t = (Translation)entity;
            operation.AddVarcharParam(DbColUser, t.User);
            operation.AddDateTimeParam(DbColDate, t.Date);
            operation.AddVarcharParam(DbColLanguage, t.Language);
            operation.AddVarcharParam(DbColSpanishSentence, t.SpanishSentence);
            operation.AddVarcharParam(DbColTranslatedSentence, t.TranslatedSentence);
            operation.AddIntParam(DbColPopularity, t.Popularity);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRANSLATIONS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
