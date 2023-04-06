using DTOs;
using MySql.Data.MySqlClient;
using System;

namespace DatabaseGateway
{
    class FindEmployeeByName : DatabaseSelector<EmployeeDTO>
    {

        private string employeeName;

        public FindEmployeeByName(string employeeName)
        {
            this.employeeName = employeeName;
        }

        protected override string GetSQL()
        {
            return
                "SELECT ID , EMPLOYEE_NAME FROM EMPLOYEES WHERE EMPLOYEE_NAME= @employeeName";
        }

        protected override EmployeeDTO DoSelect(MySqlCommand command)
        {
            EmployeeDTO employee = null;

            try
            {
                command.Parameters.AddWithValue("@employeeName", employeeName);
                command.Prepare();
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    
                    employee =
                        new EmployeeDTO_Builder()
                            .WithId(dr.GetInt32(0))
                            .WithemployeeName(dr.GetString(1))
                            .Build();
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: Employee Not found", e);
            }

            return employee;
        }
    }
}
