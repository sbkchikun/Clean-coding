using DTOs;
using MySql.Data.MySqlClient;
using System;

namespace DatabaseGateway
{
    class FindItemById : DatabaseSelector<ItemDTO>
    {

        private int ItemId;

        public FindItemById(int itemId)
        {
            this.ItemId = itemId;
        }

        protected override string GetSQL()
        {
            return
                "SELECT ID , ITEM_NAME, ITEM_QTY FROM STOCK WHERE ID= @Id";
        }

        protected override ItemDTO DoSelect(MySqlCommand command)
        {
            ItemDTO Item = null;

            try
            {
                command.Parameters.AddWithValue("@Id", ItemId);
                command.Prepare();
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    
                    Item =
                        new ItemDTO_Builder()
                            .WithId(dr.GetInt32(0))
                            .WithitemName(dr.GetString(1))
                            .WithQTY(dr.GetInt32(2))
                            .Build();
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: Item Not found", e);
            }

            return Item;
        }
    }
}
