using System;

namespace DTOs
{
    [Serializable]
    public class EmployeeDTO : DTO
    {
        public int Id { get; }
        public string EmployeeName { get; }
        public EmployeeDTO(int id, string employeeName)
        {
            this.Id = id;
            this.EmployeeName = employeeName;
            
        }
    }
}
