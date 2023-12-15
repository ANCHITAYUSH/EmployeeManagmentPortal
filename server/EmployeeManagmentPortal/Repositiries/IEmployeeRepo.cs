using EmployeeManagmentPortal.Commons.Model;

namespace EmployeeManagmentPortal.Repositiries
{
    public interface IEmployeeRepo
    {
        public Task<Response<Employee>> CreateEmployee(Employee employee);
        public Task<Response<Employee>> UpdateEmployee(int id, Employee employee);
        public Task<Response<Employee>> DeleteEmployee(int id);
        public Task<Response<List<Employee>>> ReadEmployee();
        public Task<Response<List<Employee>>> ReadEmployeeById(int id);
    }
}
