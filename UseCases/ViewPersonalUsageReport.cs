using DTOs;
using System;
namespace UseCases
{
    public class ViewPersonalUsageReport : AbstractUseCase
    {
        private readonly string employeeName;
        public ViewPersonalUsageReport(string employeeName, IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
            this.employeeName = employeeName;
        }

        public override DTO Execute()
        {
            EmployeeDTO e = gatewayFacade.FindEmployee(employeeName);
            if (e == null)
            { return new TransactionDTO_List(null); }
            return new TransactionDTO_List(gatewayFacade.FindTransactionsByEmployee(employeeName));
            
            
        }
    }
}
