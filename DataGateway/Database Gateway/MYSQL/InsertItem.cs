using DTOs;
using MySql.Data.MySqlClient;
using System;

namespace DatabaseGateway
{
    class InsertItem : DatabaseInserter<ItemDTO>
    {

        protected override string GetSQL()
        {
            return
                "INSERT INTO Stock (ID,ITEM_NAME, ITEM_QTY,DATE_CREATED) " +
                "VALUES (@ItemId,@ItemName,@QTY,@date)";
        }

        protected override int DoInsert(MySqlCommand command, ItemDTO itemToInsert)
        {
            string errorMsg = "";

            if (itemToInsert.Id < 1)
            {
                errorMsg += "ID below 1; ";
            }

            if (itemToInsert.QTY < 1)
            {
                errorMsg += "Quantity below 1; ";
            }

            if (itemToInsert.ItemName.Length == 0)
            {
                errorMsg += "Item name is empty; ";
            }

            if (errorMsg.Length > 0)
            {
                throw new Exception("ERROR: " + errorMsg);
            }
            command.Parameters.AddWithValue("@Itemid", itemToInsert.Id);
            command.Parameters.AddWithValue("@ItemName", itemToInsert.ItemName);
            command.Parameters.AddWithValue("@QTY", itemToInsert.QTY);
            command.Parameters.AddWithValue("@date", itemToInsert.DateCreated);
            command.Prepare();
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: item not inserted");
            }
            return numRowsAffected;
        }
    }
}
