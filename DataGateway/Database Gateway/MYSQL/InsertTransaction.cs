using DTOs;
using MySql.Data.MySqlClient;
using System;

namespace DatabaseGateway
{
    class InsertTransaction : DatabaseInserter<TransactionDTO>
    {

        protected override string GetSQL()
        {
            return
                "INSERT INTO TRANSACTIONS (TRANSACTION_TYPE,ITEM_NAME,ITEM_ID,COST,AMOUNT,EMPLOYEE_NAME,TRANSACTIONTIME) " +
                "VALUES (@transactionType,@itemName,@itemId,@cost,@amount,@employeeName,@transactionTime)";
        }

        protected override int DoInsert(MySqlCommand command, TransactionDTO transactionToInsert)
        {
            command.Parameters.AddWithValue("@transactionType", transactionToInsert.TransactionType);
            command.Parameters.AddWithValue("@itemName", transactionToInsert.ItemName);
            command.Parameters.AddWithValue("@itemId", transactionToInsert.ItemId);
            command.Parameters.AddWithValue("@cost", transactionToInsert.itemPrice);
            command.Parameters.AddWithValue("@amount", transactionToInsert.itemQTY);
            command.Parameters.AddWithValue("@employeeName", transactionToInsert.EmployeeName);
            command.Parameters.AddWithValue("@transactionTime", transactionToInsert.TransactionTime);
            command.Prepare();
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: transaction not logged");
            }
            return numRowsAffected;
        }
    }
}
