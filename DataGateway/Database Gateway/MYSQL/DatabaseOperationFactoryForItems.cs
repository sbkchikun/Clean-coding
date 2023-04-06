using DTOs;
using System.Collections.Generic;

namespace DatabaseGateway
{
    class DatabaseOperationFactoryForItems
    {
        public const int SELECT_ALL = 1;
        public const int SELECT_BY_ID = 2;
        public const int UPDATE_ITEM_ADD_QTY = 3;
        public const int UPDATE_ITEM_REMOVE_QTY = 4;
        public DatabaseInserter<ItemDTO> CreateInserter()
        {
            return new InsertItem();
        }

        public ISelector<List<ItemDTO>> CreateSelector(int typeOfSelection)
        {
            if (typeOfSelection == SELECT_ALL)
            {
                return new GetAllItems();
            }
            return new NullSelector<List<ItemDTO>>();
        }

        public ISelector<ItemDTO> CreateSelector(int typeOfSelection, int i)
        {
            switch (typeOfSelection)
            {
                case SELECT_BY_ID:
                    return new FindItemById(i);
                default:
                    return new NullSelector<ItemDTO>();
            }
        }
        public IUpdater<ItemDTO> CreateUpdater(int typeOfUpdate)
        {
            switch (typeOfUpdate)
            {
                case UPDATE_ITEM_ADD_QTY:
                    return new UpdateItemAddQTY();
                case UPDATE_ITEM_REMOVE_QTY:
                    return new UpdateItemRemoveQTY();
                default:
                    return null;
            }
        }
    }
}
