using DatabaseGateway;
using DTOs;
using UseCases;

namespace Controllers
{
    public class ViewTransactionLogController : AbstractController
    {

        public ViewTransactionLogController(
            AbstractPresenter presenter) : base(new DatabaseGatewayFacade(), presenter)
        {
        }

        public override DTO ExecuteUseCase()
        {
            return new ViewTransactionLog(gatewayFacade).Execute();
        }
    }
}
