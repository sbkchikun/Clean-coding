using System;
using System.Collections.Generic;

namespace DTOs
{
    [Serializable]
    public class ItemDTO_List : DTO
    {
        public List<ItemDTO> List { get; }

        public ItemDTO_List(List<ItemDTO> list)
        {
            List = list;
        }
    }
}
