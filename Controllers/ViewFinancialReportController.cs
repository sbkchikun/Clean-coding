using DatabaseGateway;
using DTOs;
using UseCases;

namespace Controllers
{
    public class ViewFinancialReportController : AbstractController
    {

        public ViewFinancialReportController(
            AbstractPresenter presenter) : base(new DatabaseGatewayFacade(), presenter)
        {
        }

        public override DTO ExecuteUseCase()
        {
            return new ViewFinancialReport(gatewayFacade).Execute();
        }
    }
}
