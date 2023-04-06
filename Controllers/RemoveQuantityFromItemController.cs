using DatabaseGateway;
using DTOs;
using UseCases;

namespace Controllers
{
    public class RemoveQuantityFromItemController : AbstractController
    {

        private int itemId;
        private int amount;
        private string employeeName;
        

        public RemoveQuantityFromItemController(
            string employeeName,
            int itemId,
            int amount,
            
            AbstractPresenter presenter) : base(new DatabaseGatewayFacade(), presenter)
        {
            this.itemId = itemId;
            this.amount = amount;
            this.employeeName = employeeName;
            
        }

        public override DTO ExecuteUseCase()
        {
            return new RemoveQuantityFromItem(employeeName, itemId, amount, gatewayFacade).Execute();
        }
    }
}
