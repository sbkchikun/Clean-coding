using DatabaseGateway;
using DTOs;
using UseCases;

namespace Controllers
{
    public class AddItemToStockController : AbstractController
    {

        private int itemId;
        private int amount;
        private string employeeName;
        private string itemName;
        private double cost;

        public AddItemToStockController(
            string employeeName,
            int itemId,
            string itemName,
            int amount, 
            double cost,
            AbstractPresenter presenter) : base(new DatabaseGatewayFacade(), presenter)
        {
            this.itemId = itemId;
            this.amount = amount;
            this.employeeName = employeeName;
            this.cost = cost;
            this.itemName=itemName;
        }

        public override DTO ExecuteUseCase()
        {
            return new AddItemToStock(employeeName, itemId,itemName, amount, cost, gatewayFacade).Execute();
        }
    }
}
