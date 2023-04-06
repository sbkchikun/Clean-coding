using System;
using System.Collections.Generic;

namespace DTOs
{
    [Serializable]
    public class TransactionDTO_List : DTO
    {
        public List<TransactionDTO> List { get; }

        public TransactionDTO_List(List<TransactionDTO> list)
        {
            List = list;
        }
    }
}
