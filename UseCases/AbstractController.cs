using DTOs;

namespace UseCases
{
    public abstract class AbstractController
    {

        protected readonly IDatabaseGatewayFacade gatewayFacade;
        protected AbstractPresenter presenter;

        public AbstractController(IDatabaseGatewayFacade database, AbstractPresenter presenter)
        {
            this.gatewayFacade = database;
            this.presenter = presenter;
        }

        public ViewData Execute()
        {
            presenter.DataToPresent = ExecuteUseCase();
            return presenter.ViewData;
        }

        public abstract DTO ExecuteUseCase();
    }
}
