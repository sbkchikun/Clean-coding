using DatabaseGateway;
using DTOs;
using UseCases;

namespace Controllers
{
    public class ViewInventoryReportController : AbstractController
    {

        public ViewInventoryReportController(
            AbstractPresenter presenter) : base(new DatabaseGatewayFacade(), presenter)
        {
        }

        public override DTO ExecuteUseCase()
        {
            return new ViewInventoryReport(gatewayFacade).Execute();
        }
    }
}
