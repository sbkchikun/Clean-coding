using DTOs;

namespace UseCases
{
    public class ViewFinancialReport : AbstractUseCase
    {

        public ViewFinancialReport(IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
        }

        public override DTO Execute()
        {
            return new TransactionDTO_List(gatewayFacade.GetAllTransactions());
        }
    }
}
