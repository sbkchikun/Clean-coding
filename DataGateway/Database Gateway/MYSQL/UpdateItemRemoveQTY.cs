using DTOs;
using MySql.Data.MySqlClient;
using System;

namespace DatabaseGateway
{
    class UpdateItemRemoveQTY : DatabaseUpdater<ItemDTO>
    {

        protected override string GetSQL()
        {
            return
                "UPDATE STOCK " +
                "SET ITEM_QTY := ITEM_QTY - @amount WHERE Id = @itemId";
        }

        protected override int DoUpdate(MySqlCommand command,ItemDTO ItemToUpdate,int amount)
        {
            int numRowsAffected = 0;
            if (amount < 0)
            {
                throw new Exception("ERROR: Quantity being removed is below 0");
            }

            if (amount > ItemToUpdate.QTY)
            {
                throw new Exception("ERROR: Quantity too many");
            }
            if (ItemToUpdate != null)
            {
                try
                {
                    ItemDTO UpdatedItem = new ItemDTO_Builder()
                   .WithId(ItemToUpdate.Id)
                   .WithitemName(ItemToUpdate.ItemName)
                   .WithQTY(amount)
                   .Build();
                    command.Parameters.AddWithValue("@amount", UpdatedItem.QTY);
                    command.Parameters.AddWithValue("@itemId", UpdatedItem.Id);
                    command.Prepare();
                    numRowsAffected = command.ExecuteNonQuery();

                    if (numRowsAffected != 1)
                    {
                        throw new Exception("ERROR: Item not updated");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
            return numRowsAffected;
        }
    }
}
