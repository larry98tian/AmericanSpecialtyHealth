namespace EmployeeManagement.DTO
{
    public class EmployeeDto
    {
        public int WorkerTypeID { get; set; }
        public string WorkerTypeName { get; set; }
        public int WorkerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public decimal? PayPerHour { get; set; }
        public decimal? AnnualSalary { get; set; }
        public decimal? MaxExpenseAmount { get; set; }
    }

}