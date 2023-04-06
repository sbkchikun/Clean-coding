using DatabaseGateway;
using DTOs;
using UseCases;

namespace Controllers
{
    public class AddQuantityToItemController : AbstractController
    {

        private int itemId;
        private int amount;
        private string employeeName;
        private double cost;

        public AddQuantityToItemController(
            string employeeName,
            int itemId,
            int amount,
            double cost,
            AbstractPresenter presenter) : base(new DatabaseGatewayFacade(), presenter)
        {
            this.itemId = itemId;
            this.amount = amount;
            this.employeeName = employeeName;
            this.cost = cost;
        }

        public override DTO ExecuteUseCase()
        {
            return new AddQuantityToItem(employeeName, itemId, amount, cost, gatewayFacade).Execute();
        }
    }
}
