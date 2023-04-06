using DTOs;
using MySql.Data.MySqlClient;
using System;

using System.Collections.Generic;

namespace DatabaseGateway
{
    class FindTransactionsByEmployee : DatabaseSelector<List<TransactionDTO>>
    {

        private string employeeName;

        public FindTransactionsByEmployee(string employeeName)
        {
            this.employeeName = employeeName;
        }

        protected override string GetSQL()
        {
            return
                "SELECT TRANSACTION_TYPE ,ITEM_NAME,ITEM_ID,COST,AMOUNT, EMPLOYEE_NAME,TRANSACTIONTIME FROM TRANSACTIONS WHERE EMPLOYEE_NAME = @employeeName";
        }

        protected override List<TransactionDTO> DoSelect(MySqlCommand command)
        {
            List<TransactionDTO> list = new List<TransactionDTO>();
            
            try
            {
                
                command.Parameters.AddWithValue("@employeeName", employeeName);
                command.Prepare();
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
                    list.Add(transaction);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: Transactions Not found", e);
            }

            return list;
        }
    }
}
