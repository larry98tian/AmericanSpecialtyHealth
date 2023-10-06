using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Data
{
    public class Employee
    {
        [ForeignKey("Worker")]
        public int EmployeeId { get; set; }
        public Worker? Worker { get; set; }
        [Precision(5, 2)]
        public decimal PayPerHour { get; set; }
    }
}
