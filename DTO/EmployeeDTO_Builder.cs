namespace DTOs
{
    public class EmployeeDTO_Builder
    {
        private int id;
        private string employeeName;
        public EmployeeDTO Build()
        {
            return
                new EmployeeDTO(id, employeeName);
        }

        public EmployeeDTO_Builder WithemployeeName(string employeeName)
        {
            this.employeeName = employeeName;
            return this;
        }

        public EmployeeDTO_Builder WithId(int id)
        {
            this.id = id;
            return this;
        }
    }
}
