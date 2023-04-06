using DTOs;

namespace UseCases
{
    public class ViewInventoryReport : AbstractUseCase
    {

        public ViewInventoryReport(IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
        }

        public override DTO Execute()
        {
            return new ItemDTO_List(gatewayFacade.GetAllItems());
        }
    }
}
