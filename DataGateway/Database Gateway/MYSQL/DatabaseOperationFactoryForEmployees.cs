using DTOs;
using System.Collections.Generic;

namespace DatabaseGateway
{
    class DatabaseOperationFactoryForEmployees
    {
        public const int SELECT_ALL = 1;
        public const int SELECT_BY_ID = 2;

        public DatabaseInserter<EmployeeDTO> CreateInserter()
        {
            return new InsertEmployee();
        }

        public ISelector<List<EmployeeDTO>> CreateSelector(int typeOfSelection)
        {
            if (typeOfSelection == SELECT_ALL)
            {
                return new GetAllEmployees();
            }
            return new NullSelector<List<EmployeeDTO>>();
        }

        public ISelector<EmployeeDTO> CreateSelector(int typeOfSelection, string name)
        {
            switch (typeOfSelection)
            {
                case SELECT_BY_ID:
                    return new FindEmployeeByName(name);
                default:
                    return new NullSelector<EmployeeDTO>();
            }
        }
    }
}
