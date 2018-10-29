using System;
using System.Collections.Generic;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class UserMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DbColId = "ID";
        private const string DbColName = "NAME";

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var user = new User
            {
                UserId = GetStringValue(row, DbColId),
                Name = GetStringValue(row, DbColName)
            };

            return user;
        }


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_USER_PR" };

            var c = (User)entity;
            operation.AddVarcharParam(DbColId, c.UserId);
            operation.AddVarcharParam(DbColName, c.Name);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USER_PR" };

            var c = (User)entity;
            operation.AddVarcharParam(DbColId, c.UserId);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USERS_PR" };
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
