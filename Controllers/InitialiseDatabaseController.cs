using DatabaseGateway;
using DTOs;
using UseCases;

namespace Controllers
{
    public class InitialiseDatabaseController : AbstractController
    {
        public InitialiseDatabaseController(
            AbstractPresenter presenter) : base(new DatabaseGatewayFacade(), presenter)
        {
        }

        public override DTO ExecuteUseCase()
        {
            return new InitialiseData(gatewayFacade).Execute();
        }
    }
}
