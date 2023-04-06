using DTOs;
using System;
using System.Collections.Generic;
using UseCases;

namespace DatabaseGateway
{
    public class DatabaseGatewayFacade : IDatabaseGatewayFacade
    {

        public DatabaseGatewayFacade()
        {

        }

        public int AddEmployee(EmployeeDTO b)
        {
            return new DatabaseOperationFactoryForEmployees()
                .CreateInserter()
                .Insert(b);
        }
        public int AddQuantity( int itemId, int amount)
        {
            ItemDTO ItemToUpdate = FindItem(itemId);
            if (ItemToUpdate == null)
            {
                throw new Exception("ERROR: Item not found");
            }

           return new DatabaseOperationFactoryForItems()
                .CreateUpdater(DatabaseOperationFactoryForItems.UPDATE_ITEM_ADD_QTY)
                .Update(ItemToUpdate,amount);
        }
        public int RemoveQuantity(int itemId, int amount)
        {
            ItemDTO ItemToUpdate = FindItem(itemId);

            if (ItemToUpdate == null)
            {
                throw new Exception("ERROR: Item not found");
            }

            return new DatabaseOperationFactoryForItems()
                 .CreateUpdater(DatabaseOperationFactoryForItems.UPDATE_ITEM_REMOVE_QTY)
                 .Update(ItemToUpdate, amount);
        }


        public EmployeeDTO FindEmployee(string employeeName)
        {
            return new DatabaseOperationFactoryForEmployees()
                .CreateSelector(DatabaseOperationFactoryForEmployees.SELECT_BY_ID, employeeName)
                .Select();
        }





        public List<EmployeeDTO> GetAllEmployees()
        {
            return new DatabaseOperationFactoryForEmployees()
                .CreateSelector(DatabaseOperationFactoryForEmployees.SELECT_ALL)
                .Select();
        }

        
            public List<TransactionDTO> GetAllTransactions()
        {
            return new DatabaseOperationFactoryForTransactions()
                .CreateSelector(DatabaseOperationFactoryForTransactions.SELECT_ALL)
                .Select();
        }
        public List<TransactionDTO> FindTransactionsByEmployee(string employeeName)
        {
            return new DatabaseOperationFactoryForTransactions()
                .CreateSelector(DatabaseOperationFactoryForTransactions.SELECT_BY_NAME, employeeName)
                .Select();
        }
        public int AddItem(ItemDTO i) {
            return new DatabaseOperationFactoryForItems()
            .CreateInserter()
            .Insert(i); }

        public int AddTransactionLog(TransactionDTO T)
        {
            return new DatabaseOperationFactoryForTransactions()
            .CreateInserter()
            .Insert(T);
        }

        public ItemDTO FindItem(int itemId){
            return new DatabaseOperationFactoryForItems()
                .CreateSelector(DatabaseOperationFactoryForItems.SELECT_BY_ID, itemId)
                .Select();
            
            
            ;}
        public List<ItemDTO> GetAllItems()
        {
            return new DatabaseOperationFactoryForItems()
            .CreateSelector(DatabaseOperationFactoryForItems.SELECT_ALL)
            .Select();
        }
        public void InitialiseDatabase()
        {
            new DatabaseInitialiser().Initialise();
        }

        
    }
}
