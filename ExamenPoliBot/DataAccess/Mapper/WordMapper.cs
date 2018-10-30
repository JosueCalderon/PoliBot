using System;
using System.Collections.Generic;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    class WordMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DbColWord = "WORD";
        private const string DbColLanguage = "LANGUAGE";
        private const string DbColTransQuantity = "TRANSLATIONS_QUANTITY";

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var word = BuildObject(row);
                lstResults.Add(word);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var word = new Word
            {
                Words = GetStringValue(row, DbColWord),
                Language = GetStringValue(row, DbColLanguage),
                TranslationQuantity = GetIntValue(row, DbColTransQuantity)

            };

            return word;
        }


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_WORD_PR" };

            var w = (Word)entity;
            operation.AddVarcharParam(DbColWord, w.Words);
            operation.AddVarcharParam(DbColLanguage, w.Language);
            operation.AddIntParam(DbColLanguage, 0);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_WORD_PR" };

            var w = (Word)entity;
            operation.AddVarcharParam(DbColWord, w.Words);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_WORDS_PR" };
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
