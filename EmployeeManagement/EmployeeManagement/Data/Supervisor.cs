using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Data
{
    public class Supervisor
    {
        [ForeignKey("Worker")]
        public int SupervisorId { get; set; }
        public Worker? Worker { get; set; }
        [Precision(10, 2)]
        public decimal AnnualSalary { get; set; }
    }
}
