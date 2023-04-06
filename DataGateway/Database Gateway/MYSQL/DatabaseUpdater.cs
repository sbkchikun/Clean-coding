using MySql.Data.MySqlClient;
using System;

namespace DatabaseGateway
{

   
    abstract class DatabaseUpdater<T> : DatabaseOperator, IUpdater<T>
    {

        public int Update(T itemToUpdate,int amount)
        {
            int numRowsUpdated = 0;

            MySqlConnection conn = GetConnection();

            MySqlCommand command = GetCommand(conn);

            try
            {
                numRowsUpdated = DoUpdate(command, itemToUpdate,amount);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            ReleaseConnection(conn);
            return numRowsUpdated;
        }

        protected abstract int DoUpdate(MySqlCommand command, T itemToUpdate, int amount);
        protected override abstract string GetSQL();
    }
}