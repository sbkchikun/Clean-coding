using System;
namespace DTOs
{
    public class ItemDTO_Builder
    {
        private int id;
        private string itemName;
        private int qty;
        public ItemDTO Build()
        {
            return
                new ItemDTO(id, itemName, qty,DateTime.Today);
        }

        public ItemDTO_Builder WithitemName(string itemName)
        {
            this.itemName = itemName;
            return this;
        }

        public ItemDTO_Builder WithId(int id)
        {
            this.id = id;
            return this;
        }
        public ItemDTO_Builder WithQTY(int qty)
        {
            this.qty = qty;
            return this;
        }
    }
}
