using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseGateway
{
    class DatabaseInitialiser
    {

        private readonly MySqlCommand creatEmployeesTable = new MySqlCommand
        {
            CommandText = "CREATE TABLE EMPLOYEES(ID int NOT NULL AUTO_INCREMENT,EMPLOYEE_NAME VARCHAR(25),PRIMARY KEY(ID));",
            CommandType = CommandType.Text
        };

        private readonly MySqlCommand createStockTable = new MySqlCommand
        {
            CommandText = "CREATE TABLE STOCK (ID int NOT NULL AUTO_INCREMENT,ITEM_NAME VARCHAR(25) NOT NULL,ITEM_QTY int,DATE_CREATED DATETIME,PRIMARY KEY(ID));",
            CommandType = CommandType.Text
        };

        private readonly MySqlCommand createTransactionsTable = new MySqlCommand
        {
            CommandText = "CREATE TABLE TRANSACTIONS(TRANSACTION_TYPE VARCHAR(25),ITEM_NAME VARCHAR(25),ITEM_ID INT REFERENCES STOCK(ID),COST FLOAT,AMOUNT INT,EMPLOYEE_NAME VARCHAR(15),TRANSACTIONTIME DATETIME);",
            CommandType = CommandType.Text
        };

        private readonly MySqlCommand dropTransactionsTable = new MySqlCommand
        {
            CommandText = "DROP TABLE TRANSACTIONS",
            CommandType = CommandType.Text
        };

        private readonly MySqlCommand dropEmployeesTable = new MySqlCommand
        {
            CommandText = "DROP TABLE EMPLOYEES",
            CommandType = CommandType.Text
        };

        private readonly MySqlCommand dropStockTable = new MySqlCommand
        {
            CommandText = "DROP TABLE STOCK",
            CommandType = CommandType.Text
        };

        private readonly List<MySqlCommand> commandSequence;

        public DatabaseInitialiser()
        {
            commandSequence = new List<MySqlCommand>()
            {

               dropEmployeesTable,
               dropStockTable,
               dropTransactionsTable
               ,
               creatEmployeesTable,
               createStockTable,
               createTransactionsTable
            };
        }

        public void Initialise()
        {
            DatabaseConnectionPool connectionPool = DatabaseConnectionPool.GetInstance();
            MySqlConnection conn = connectionPool.AcquireConnection();

            foreach (MySqlCommand c in commandSequence)
            {
                try
                {
                    c.Connection = conn;
                    c.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("ERROR: SQL command failed\n" + e.StackTrace, e);
                }
            }

            connectionPool.ReleaseConnection(conn);
        }
    }
}
