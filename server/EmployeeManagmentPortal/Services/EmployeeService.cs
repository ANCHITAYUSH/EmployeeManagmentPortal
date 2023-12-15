using EmployeeManagmentPortal.Commons.Model;
using EmployeeManagmentPortal.Repositiries;

namespace EmployeeManagmentPortal.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeRepo _employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo) 
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<Response<Employee>> CreateEmployee(Employee employee)
        {
            return await _employeeRepo.CreateEmployee(employee);
        }

        public Task<Response<Employee>> DeleteEmployee(int id)
        {
            return _employeeRepo.DeleteEmployee(id);
        }

        public async Task<Response<List<Employee>>> ReadEmployee()
        {
            return await _employeeRepo.ReadEmployee();
        }

        public async Task<Response<List<Employee>>> ReadEmployeeById(int id)
        {
            return await _employeeRepo.ReadEmployeeById(id);
        }

        public async Task<Response<Employee>> UpdateEmployee(int id, Employee employee)
        {
            return await _employeeRepo.UpdateEmployee(id, employee);
        }
    }
}
