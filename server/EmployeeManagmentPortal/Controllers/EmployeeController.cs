using EmployeeManagmentPortal.Commons;
using EmployeeManagmentPortal.Commons.Model;
using EmployeeManagmentPortal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagmentPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Request<Employee> request)
        {
            Response<Employee> response = null;

            try
            {
                response = await _employeeService.CreateEmployee(request.RequestBody);
            }
            catch (Exception ex)
            {
                response.Status = Const.Error;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id,Request<Employee> request)
        {
            Response<Employee> response = null;

            try
            {
                response = await _employeeService.UpdateEmployee(id, request.RequestBody);
            }
            catch (Exception ex)
            {
                response.Status = Const.Error;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            Response<Employee> response = null;

            try
            {
                response = await _employeeService.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                response.Status = Const.Error;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ReadEmployee()
        {
            Response<List<Employee>> response = null;

            try
            {
                response = await _employeeService.ReadEmployee();
            }
            catch (Exception ex)
            {
                response.Status = Const.Error;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ReadEmployeeById([FromRoute] int id)
        {
            Response<List<Employee>> response = null;

            try
            {
                response = await _employeeService.ReadEmployeeById(id);
            }
            catch (Exception ex)
            {
                response.Status = Const.Error;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);

        }

    }
}
