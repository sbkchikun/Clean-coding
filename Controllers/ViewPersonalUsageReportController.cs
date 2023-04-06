using DatabaseGateway;
using DTOs;
using UseCases;

namespace Controllers
{
    public class ViewPersonalUsageReportController : AbstractController
    {
        private string employeeName;
        public ViewPersonalUsageReportController(string employeeName,
            AbstractPresenter presenter) : base(new DatabaseGatewayFacade(), presenter)
        {
            this.employeeName = employeeName;
        }

        public override DTO ExecuteUseCase()
        {
            
            return new ViewPersonalUsageReport(employeeName,gatewayFacade).Execute();
        }
    }
}
