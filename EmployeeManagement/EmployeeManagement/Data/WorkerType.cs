using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Data
{
    public class WorkerType
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }

    }
}
