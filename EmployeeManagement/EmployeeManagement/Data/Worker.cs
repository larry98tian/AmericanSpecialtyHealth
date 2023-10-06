using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Data
{
    public class Worker
    {
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(100)]
        public string Address1 { get; set; }
        public int WorkerTypeId{get;set;}
        public WorkerType? WorkerType { get;set;}
    }
}
