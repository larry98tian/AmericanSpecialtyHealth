using EmployeeManagement.DTO;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        int CreateEmployee(CreateEmployeeDto createEmployeeDto);
        List<EmployeeDto> GetEmployees();
    }
}
