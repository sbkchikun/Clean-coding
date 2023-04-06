using DTOs;
using System;

namespace UseCases
{
    public class AddItemToStock : AbstractUseCase
    {

        private readonly int itemQty;
        private readonly int itemId;
        private readonly string employeeName;
        private readonly double itemPrice;
        private readonly string itemName;

        public AddItemToStock(string employeeName, int itemId,string itemName, int itemQty,double itemPrice, IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
            this.itemQty = itemQty;
            this.itemId = itemId;
            this.employeeName = employeeName;
            this.itemPrice = itemPrice;
            this.itemName=itemName;
            
        }

        public override DTO Execute()
        {
            

                try
                {
                EmployeeDTO m = gatewayFacade.FindEmployee(employeeName);
                if (m == null) 
                { return new MessageDTO("ERROR: Employee not found"); }
                if (itemPrice < 0)
                { return new MessageDTO("ERROR: Price below 0"); }
                gatewayFacade.AddItem(new ItemDTO_Builder()
                    .WithId(itemId)
                    .WithitemName(itemName)
                    .WithQTY(itemQty)
                    .Build());
                gatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                .WithtransactionType("Item Added")
                .WithitemId(itemId)
                .WithitemName(itemName)
                .WithitemPrice(itemPrice)
                .WithitemQTY(itemQty)
                .WithemployeeName(employeeName)
                .Build()); 
                return new MessageDTO("Item added");
            }
            catch (Exception e)
            {
                return new MessageDTO(e.Message);
            }
        }
            
        
    }
}
