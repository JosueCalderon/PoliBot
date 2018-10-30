using System;
using System.Collections.Generic;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    class LanguageMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DbColLanguage = "LANGUAGE";
        private const string DbColPopularity = "POPULARITY";

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var language = BuildObject(row);
                lstResults.Add(language);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var language = new Language
            {
                Languages = GetStringValue(row, DbColLanguage),
                Popularity = GetStringValue(row, DbColPopularity)
            };

            return language;
        }


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_LANGUAGE_PR" };

            var l = (Language)entity;
            operation.AddVarcharParam(DbColLanguage, l.Languages);
            operation.AddIntParam(DbColPopularity, 0);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_LANGUAGES_PR" };
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
