using DTOs;
using System.Collections.Generic;

namespace UseCases
{

    public interface IDatabaseGatewayFacade
    {
        public int AddEmployee(EmployeeDTO e);

        

        public EmployeeDTO FindEmployee(string employeeId);

        public int AddQuantity(int itemId, int amount);
        public int RemoveQuantity(int itemId, int amount);
        public List<EmployeeDTO> GetAllEmployees();
        public List<TransactionDTO> FindTransactionsByEmployee(string employee);
        
        public int AddTransactionLog(TransactionDTO t);
        public int AddItem(ItemDTO i);
        public ItemDTO FindItem(int itemId);
        public List<ItemDTO> GetAllItems();
        public List<TransactionDTO> GetAllTransactions();
        
        public void InitialiseDatabase();

        
    }
}
