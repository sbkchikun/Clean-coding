using DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DatabaseGateway
{
    class GetAllItems : DatabaseSelector<List<ItemDTO>>
    {

        public GetAllItems()
        {

        }

        protected override string GetSQL()
        {
            return
                "SELECT ID ,ITEM_NAME,ITEM_QTY FROM STOCK";
        }

        protected override List<ItemDTO> DoSelect(MySqlCommand command)
        {
            List<ItemDTO> Stock = new List<ItemDTO>();
            try
            {
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    
                    ItemDTO book =
                        new ItemDTO_Builder()
                            .WithId(dr.GetInt32(0))
                            .WithitemName(dr.GetString(1))
                            .WithQTY(dr.GetInt32(2))
                            .Build();
                    Stock.Add(book);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of Stock failed", e);
            }

            return Stock;
        }
    }
}
