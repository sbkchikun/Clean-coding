using DTOs;
using System;
namespace UseCases
{
    public class InitialiseData : AbstractUseCase
    {

        public InitialiseData(IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
        }

        public override DTO Execute()
        {
            gatewayFacade.InitialiseDatabase();

            gatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Graham")
                    .Build());
            gatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Phil")
                    .Build());
            gatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Jan")
                    .Build());
            gatewayFacade.AddItem(
                            new ItemDTO_Builder()
                                .WithitemName("Pencil")
                                .WithId(1)
                                .WithQTY(10)
                                .Build());
            gatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                .WithtransactionType("Item Added")
                .WithitemId(1)
                .WithitemName("Pencil")
                .WithitemPrice(0.25)
                .WithitemQTY(10)
                .WithemployeeName("Graham")
                .Build());
            gatewayFacade.AddItem(
                            new ItemDTO_Builder()
                                .WithitemName("Eraser")
                                .WithId(2)
                                .WithQTY(20)
                                .Build());
            gatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                .WithtransactionType("Item Added")
                .WithitemId(2)
                .WithitemName("Eraser")
                .WithitemPrice(0.15)
                .WithitemQTY(20)
                .WithemployeeName("Phil")
                .Build());
            gatewayFacade.RemoveQuantity(2, 4);
            gatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
               .WithtransactionType("Quantity Removed")
               .WithitemId(2)
               .WithitemName("Eraser")
               .WithitemPrice(-1)
               .WithitemQTY(4)
               .WithemployeeName("Graham")
               
               .Build());
            gatewayFacade.AddQuantity(2, 2);
            gatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
               .WithtransactionType("Quantity Added")
               .WithitemId(2)
               .WithitemName("Eraser")
               .WithitemPrice(0.33)
               .WithitemQTY(2)
               .WithemployeeName("Phil")
               .Build());


            return new MessageDTO("nishalised databayse");
        }
    }
}
