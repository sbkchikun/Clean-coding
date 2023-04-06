using DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DatabaseGateway
{
    class GetAllEmployees : DatabaseSelector<List<EmployeeDTO>>
    {

        public GetAllEmployees()
        {

        }

        protected override string GetSQL()
        {
            return
                "SELECT ID ,EMPLOYEE_NAME FROM EMPLOYEES";
        }

        protected override List<EmployeeDTO> DoSelect(MySqlCommand command)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            try
            {
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    
                    EmployeeDTO employee =
                        new EmployeeDTO_Builder()
                            .WithId(dr.GetInt32(0))
                            .WithemployeeName(dr.GetString(1))
                            .Build();
                    employees.Add(employee);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of Employees failed", e);
            }

            return employees;
        }
    }
}
