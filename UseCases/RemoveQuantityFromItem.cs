using DTOs;

using System;

namespace UseCases
{
    public class RemoveQuantityFromItem : AbstractUseCase
    {

        private readonly int QTY;
        private readonly int itemId;
        private readonly string employeeName;

        public RemoveQuantityFromItem(string employeeName,int itemId, int QTY, IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
            this.QTY = QTY;
            this.itemId = itemId;
            this.employeeName = employeeName;
            
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
                gatewayFacade.RemoveQuantity(itemId, QTY);

                gatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                .WithtransactionType("Quantity Removed")
                .WithitemId(itemId)
                .WithitemName(i.ItemName)
                .WithitemPrice(-1)
                .WithitemQTY(QTY)
                .WithemployeeName(employeeName)
                .Build()); ;
                return new MessageDTO(employeeName + " has removed "+ QTY + " of Item ID: "+ itemId + " on" + DateTime.Now.ToString("dd/MM/yyyy"));
            }
            catch (Exception e)
            {
                return new MessageDTO(e.Message);
            }
        }
    }
            
        
    }

