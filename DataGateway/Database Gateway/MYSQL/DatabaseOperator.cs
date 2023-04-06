using MySql.Data.MySqlClient;
using System.Data;

namespace DatabaseGateway
{
    
    abstract class DatabaseOperator
    {
        protected MySqlConnection GetConnection()
        {
            return DatabaseConnectionPool.GetInstance().AcquireConnection();
        }

        protected MySqlCommand GetCommand(MySqlConnection conn)
        {
            return new MySqlCommand
            {
                Connection = conn,
                CommandText = GetSQL(),
                CommandType = CommandType.Text
            };
        }

        protected abstract string GetSQL();

        protected void ReleaseConnection(MySqlConnection conn)
        {
            DatabaseConnectionPool.GetInstance().ReleaseConnection(conn);
        }
    }
}
