using DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DatabaseGateway
{
    class GetAllTransactions : DatabaseSelector<List<TransactionDTO >>
    {

        public GetAllTransactions()
        {

        }

        protected override string GetSQL()
        {
            return
                "SELECT TRANSACTION_TYPE,ITEM_NAME,ITEM_ID,COST,AMOUNT,EMPLOYEE_NAME,TRANSACTIONTIME FROM transactions";
        }

        protected override List<TransactionDTO> DoSelect(MySqlCommand command)
        {
            List<TransactionDTO> Transactions = new List<TransactionDTO>();
            try
            {
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {

                    TransactionDTO transaction =
                        new TransactionDTO_Builder()
                            .WithtransactionType(dr.GetString(0))
                            .WithitemName(dr.GetString(1))
                            .WithitemId(dr.GetInt32(2))
                            .WithitemPrice(dr.GetDouble(3))
                            .WithitemQTY(dr.GetInt32(4))
                            .WithemployeeName(dr.GetString(5))
                            .Build();
                    Transactions.Add(transaction);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of Transactions failed", e);
            }

            return Transactions;
        }
    }
}
