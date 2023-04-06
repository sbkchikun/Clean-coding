using DTOs;
using System;

namespace UseCases
{
    public class AddQuantityToItem : AbstractUseCase
    {

        private readonly int QTY;
        private readonly int itemId;
        private readonly string employeeName;
        private readonly double cost;

        public AddQuantityToItem(string employeeName, int itemId, int QTY, double cost, IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
            this.QTY = QTY;
            this.itemId = itemId;
            this.employeeName = employeeName;
            this.cost = cost;
            
        }

        public override DTO Execute()
        {
            

                try
                {
                EmployeeDTO m = gatewayFacade.FindEmployee(employeeName);
                if (m == null) 
                { return new MessageDTO("ERROR: Employee not found"); }
                ItemDTO i = gatewayFacade.FindItem(itemId);
                if (i == null) 
                { return new MessageDTO("ERROR: Item not found"); }
                if(cost<0)
                { return new MessageDTO("ERROR: Price below 0"); }
                gatewayFacade.AddQuantity(itemId, QTY);

                gatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                .WithtransactionType("Quantity Added")
                .WithitemId(itemId)
                .WithitemName(i.ItemName)
                .WithitemPrice(cost)
                .WithitemQTY(QTY)
                .WithemployeeName(employeeName)
                .Build()); ;
                return new MessageDTO(employeeName + "has added "+ QTY + " of Item ID: "+ itemId + " on" + DateTime.Now.ToString("dd / MM / yyyy"));
            }
            catch (Exception e)
            {
                return new MessageDTO(e.Message);
            }
        }
            
        
    }
}
