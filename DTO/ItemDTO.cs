using System;

namespace DTOs
{
    [Serializable]
    public class ItemDTO : DTO
    {
        public int Id { get; }
        public string ItemName { get; }
        public DateTime DateCreated { get; }
        public int QTY { get; }
        public ItemDTO(int id, string itemName,int qty,DateTime dateCreated)
        {
            
            this.Id = id;
            this.ItemName = itemName;
            this.QTY = qty;
            this.DateCreated = dateCreated;
        }
    }
}
