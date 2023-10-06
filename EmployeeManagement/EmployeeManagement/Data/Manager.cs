using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Data
{
    public class Manager
    {
        [ForeignKey("Worker")]
        public int ManagerId { get; set; }
        public Worker? Worker { get; set; }
        [Precision(10, 2)]
        public decimal AnnualSalary { get; set; }
        [Precision(10, 2)]
        public decimal MaxExpenseAmount { get; set; }
    }
}
