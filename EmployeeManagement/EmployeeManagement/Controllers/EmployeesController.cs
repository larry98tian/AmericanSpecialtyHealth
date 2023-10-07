using EmployeeManagement.Data;
using EmployeeManagement.DTO;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IEmployeeService _employeeService;  

        public EmployeesController(EmployeeDbContext employeeDbContext, IEmployeeService employeeService)
        {
            _employeeDbContext = employeeDbContext;
            _employeeService = employeeService;
        }

        [HttpPost]
        public ActionResult CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            if ( !_employeeDbContext.WorkerTypes.Any(wt => wt.Id == createEmployeeDto.WorkerTypeID) )
            { 
                return BadRequest("Invalid WorkerTypeId");
            }
            int workerId = _employeeService.CreateEmployee(createEmployeeDto);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetEmployees() 
        {
            var employeeDtos = _employeeService.GetEmployees();
            return Ok(employeeDtos);
        }
    }
}
