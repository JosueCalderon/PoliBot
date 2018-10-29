using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Dao
{
   public class SqlDao
    {
        private const string ConnectionString =
           "Data Source=DESKTOP-T3PH9O7;Initial Catalog=POLIBOT;Integrated Security=True;Pooling=False";

        private static SqlDao _instance;

        private SqlDao()
        {
        }

        public static SqlDao GetInstance()
        {
            if (_instance == null)
                _instance = new SqlDao();

            return _instance;
        }


        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                foreach (var param in sqlOperation.Parameters) command.Parameters.Add(param);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
        {
            var lstResult = new List<Dictionary<string, object>>();

            using (var conn = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                foreach (var param in sqlOperation.Parameters) command.Parameters.Add(param);

                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        var dict = new Dictionary<string, object>();
                        for (var lp = 0; lp < reader.FieldCount; lp++)
                            dict.Add(reader.GetName(lp), reader.GetValue(lp));
                        lstResult.Add(dict);
                    }
            }

            return lstResult;
        }
    }
}
