using EmployeeManagement.Data;
using EmployeeManagement.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeesController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        [HttpPost]
        public ActionResult CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            Worker worker = new Worker() { Address1 = createEmployeeDto.Address1, FirstName = createEmployeeDto.FirstName,
                                         LastName = createEmployeeDto.LastName, WorkerTypeId = createEmployeeDto.WorkerTypeID};
            _employeeDbContext.Workers.Add(worker);
            _employeeDbContext.SaveChanges();

            if (createEmployeeDto.WorkerTypeID == 1) 
            {
                Employee employee = new Employee() { EmployeeId = worker.Id, PayPerHour = createEmployeeDto.PayPerHour.Value };
                _employeeDbContext.Employees.Add(employee);
            }
            else if (createEmployeeDto.WorkerTypeID == 2)
            {
                Supervisor supervisor = new Supervisor() { SupervisorId = worker.Id, AnnualSalary = createEmployeeDto.AnnualSalary.Value };
            }
            else if (createEmployeeDto.WorkerTypeID == 3)
            {
                Manager supervisor = new Manager() { ManagerId = worker.Id, AnnualSalary = createEmployeeDto.AnnualSalary.Value, MaxExpenseAmount = createEmployeeDto.MaxExpenseAmount.Value };
            }
            else
            {
                return BadRequest("Invalid WorkerTypeId");
            }
            _employeeDbContext.SaveChanges();
            return Ok();
        }
    }
}
