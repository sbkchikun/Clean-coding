using DTOs;
using MySql.Data.MySqlClient;
using System;

namespace DatabaseGateway
{
    class InsertEmployee : DatabaseInserter<EmployeeDTO>
    {

        protected override string GetSQL()
        {
            return
                "INSERT INTO EMPLOYEES (EMPLOYEE_NAME) " +
                "VALUES (@EMPLOYEE_NAME)";
        }

        protected override int DoInsert(MySqlCommand command, EmployeeDTO employeeToInsert)
        {
            command.Parameters.AddWithValue("@EMPLOYEE_NAME", employeeToInsert.EmployeeName);
            command.Prepare();
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: Employee not inserted");
            }
            return numRowsAffected;
        }
    }
}
