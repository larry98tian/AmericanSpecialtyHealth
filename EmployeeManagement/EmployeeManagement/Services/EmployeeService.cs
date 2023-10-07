using EmployeeManagement.Data;
using EmployeeManagement.DTO;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeService(EmployeeDbContext employeeDbContext)
        {
            this._employeeDbContext = employeeDbContext;
        }
        public int CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            Worker worker = new Worker()
            {
                Address1 = createEmployeeDto.Address1,
                FirstName = createEmployeeDto.FirstName,
                LastName = createEmployeeDto.LastName,
                WorkerTypeId = createEmployeeDto.WorkerTypeID
            };
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
                _employeeDbContext.Supervisors.Add(supervisor);
            }
            else if (createEmployeeDto.WorkerTypeID == 3)
            {
                Manager manager = new Manager() { ManagerId = worker.Id, AnnualSalary = createEmployeeDto.AnnualSalary.Value, MaxExpenseAmount = createEmployeeDto.MaxExpenseAmount.Value };
                _employeeDbContext.Managers.Add(manager);
            }
            _employeeDbContext.SaveChanges();
            return worker.Id;
        }

        public List<EmployeeDto> GetEmployees()
        {
            //List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
            var employees = from wt in _employeeDbContext.WorkerTypes
                            join w in _employeeDbContext.Workers
                            on wt.Id equals w.WorkerTypeId
                            join e in _employeeDbContext.Employees
                            on w.Id equals e.EmployeeId
                            select new EmployeeDto
                            {
                                Address1 = w.Address1.ToString(), 
                                FirstName = w.FirstName.ToString(), 
                                LastName = w.LastName.ToString(), 
                                WorkerID = w.Id,
                                PayPerHour = e.PayPerHour, 
                                WorkerTypeID = w.WorkerTypeId, 
                                WorkerTypeName = wt.Name.ToString(),
                                AnnualSalary = null, 
                                MaxExpenseAmount = null
                            };

            var supervisors = from wt in _employeeDbContext.WorkerTypes
                               join w in _employeeDbContext.Workers
                               on wt.Id equals w.WorkerTypeId
                               join s in _employeeDbContext.Supervisors
                               on w.Id equals s.SupervisorId
                               select new EmployeeDto
                               {
                                   Address1 = w.Address1.ToString(),
                                   FirstName = w.FirstName.ToString(),
                                   LastName = w.LastName.ToString(),
                                   WorkerID = w.Id,
                                   PayPerHour = null,
                                   WorkerTypeID = w.WorkerTypeId,
                                   WorkerTypeName = wt.Name.ToString(),
                                   AnnualSalary = s.AnnualSalary,
                                   MaxExpenseAmount= null,
                                   

                               };
            var managers = from wt in _employeeDbContext.WorkerTypes
                              join w in _employeeDbContext.Workers
                              on wt.Id equals w.WorkerTypeId
                              join m in _employeeDbContext.Managers
                              on w.Id equals m.ManagerId
                              select new EmployeeDto
                              {
                                  Address1 = w.Address1.ToString(),
                                  FirstName = w.FirstName.ToString(),
                                  LastName = w.LastName.ToString(),
                                  WorkerID = w.Id,
                                  PayPerHour = null,
                                  WorkerTypeID = w.WorkerTypeId,
                                  WorkerTypeName = wt.Name.ToString(),
                                  AnnualSalary = m.AnnualSalary,
                                  MaxExpenseAmount = m.MaxExpenseAmount,


                              };

            return employees.AsEnumerable().Concat(supervisors.AsEnumerable()).Concat(managers.AsEnumerable()).ToList();
        }
    }
}
