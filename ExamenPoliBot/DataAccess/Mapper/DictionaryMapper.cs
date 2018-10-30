using System;
using System.Collections.Generic;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class DictionaryMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string Dbcolword = "WORD";
        private const string Dbcolwordlanguage = "WORD_LANGUAGE";
        private const string Dbcoltranslatedword = "TRANSLATED_WORD";
        private const string DbcolTranslatedLanguage = "TRANSLATED_LANGUAGE";

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var dictionary = BuildObject(row);
                lstResults.Add(dictionary);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var dictionary = new Dictionary
            {
                Word = GetStringValue(row, Dbcolword),
                WordLanguage = GetStringValue(row, Dbcolwordlanguage),
                TranslatedWord = GetStringValue(row, Dbcoltranslatedword),
                TranslatedLanguage = GetStringValue(row, DbcolTranslatedLanguage)
            };

            return dictionary;
        }


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {

            var operation = new SqlOperation { ProcedureName = "CRE_DICTIONARY_PR" };

            var d = (Dictionary)entity;

            operation.AddVarcharParam(Dbcolword, d.Word);
            operation.AddVarcharParam(Dbcolwordlanguage, d.WordLanguage);
            operation.AddVarcharParam(Dbcoltranslatedword, d.TranslatedWord);
            operation.AddVarcharParam(DbcolTranslatedLanguage, d.TranslatedLanguage);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DICTIONARY_PR" };

            var d = (Dictionary)entity;
            operation.AddVarcharParam(Dbcolword, d.Word);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_DICTIONARIES_PR" };
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
