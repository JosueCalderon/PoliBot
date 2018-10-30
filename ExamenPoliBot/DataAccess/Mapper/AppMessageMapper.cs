using System;
using System.Collections.Generic;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    class AppMessageMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DbColId = "ID";
        private const string DbColText = "TEXT";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MESSAGE_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var appMessage = BuildObject(row);
                lstResults.Add(appMessage);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var appMessage = new ApplicationMessage
            {
                ID = GetIntValue(row, DbColId),
                Message = GetStringValue(row, DbColText)
            };

            return appMessage;
        }
    }
}
