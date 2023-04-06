using DTOs;

namespace UseCases
{
    public class ViewTransactionLog : AbstractUseCase
    {

        public ViewTransactionLog(IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
        }

        public override DTO Execute()
        {
            return new TransactionDTO_List(gatewayFacade.GetAllTransactions());
        }
    }
}
