using EmployeeManagmentPortal.Commons;
using EmployeeManagmentPortal.Commons.Model;
using System.Data.SqlClient;

namespace EmployeeManagmentPortal.Repositiries
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;

        private int ConnectionTimeOut = 180;

        public EmployeeRepo(IConfiguration configuration) 
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(configuration["ConnectionStrings:DBSettingConnection"]);
        }

        public async Task<Response<Employee>> CreateEmployee(Employee employee)
        {
            Response<Employee> response = new Response<Employee>();
            response.Status = Const.OK;
            response.Message = "Successful";
            try
            {
                if (_sqlConnection != null)
                {
                    string sqlQuery = "INSERT INTO Employees (FullName, Designation, PhoneNumber, Email) VALUES (@FullName, @Designation, @PhoneNumber, @Email)";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = ConnectionTimeOut;
                        sqlCommand.Parameters.AddWithValue("@FullName", employee.FullName);
                        sqlCommand.Parameters.AddWithValue("@Designation", employee.Designation);
                        sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                        sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
                        await _sqlConnection.OpenAsync();

                        int Status = await sqlCommand.ExecuteNonQueryAsync();
                        if (Status <= 0)
                        {
                            response.Status = Const.Error;
                            response.Message = "Create Employee Not Executed";
                        }
                        else 
                        {
                            response.ResponseBody = employee;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                response.Status = Const.Error;
                response.Message = "Exception Message : " + ex.Message;
            }
            finally
            {
                await _sqlConnection.CloseAsync();
                await _sqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<Response<Employee>> DeleteEmployee(int id)
        {
            Response<Employee> response = new Response<Employee>();
            response.Status = Const.OK;
            response.Message = "Successful";
            try
            {
                if (_sqlConnection != null)
                {
                    string sqlQuery = "DELETE FROM Employees WHERE Id=@Id";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = ConnectionTimeOut;
                        sqlCommand.Parameters.AddWithValue("@Id", id);
                        await _sqlConnection.OpenAsync();

                        int Status = await sqlCommand.ExecuteNonQueryAsync();
                        if (Status <= 0)
                        {
                            response.Status = Const.Error;
                            response.Message = "Delete Employee Not Executed";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                response.Status = Const.Error;
                response.Message = "Exception Message : " + ex.Message;
            }
            finally
            {
                await _sqlConnection.CloseAsync();
                await _sqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<Response<List<Employee>>> ReadEmployee()
        {
            Response<List<Employee>> response = new Response<List<Employee>>();
            List<Employee> employees = new List<Employee>();
            response.Status = Const.OK;
            response.Message = "Successful";
            try
            {
                if (_sqlConnection != null)
                {
                    string sqlQuery = "SELECT * FROM Employees";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        await _sqlConnection.OpenAsync();

                        using(SqlDataReader reader = await sqlCommand.ExecuteReaderAsync()) 
                        {
                            if(reader.HasRows) 
                            {
                                while (await reader.ReadAsync())
                                {
                                    Employee employee = new Employee();
                                    employee.Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
                                    employee.FullName = reader["FullName"] != DBNull.Value ? Convert.ToString(reader["FullName"]) : String.Empty;
                                    employee.PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? Convert.ToString(reader["PhoneNumber"]) : String.Empty;
                                    employee.Designation = reader["Designation"] != DBNull.Value ? Convert.ToString(reader["Designation"]) : String.Empty;
                                    employee.Email = reader["Email"] != DBNull.Value ? Convert.ToString(reader["Email"]) : String.Empty;

                                    employees.Add(employee);
                                }
                            }
                        }
                    }
                }

                response.ResponseBody = employees;

            }
            catch (Exception ex)
            {
                response.Status = Const.Error;
                response.Message = "Exception Message : " + ex.Message;
            }
            finally
            {
                await _sqlConnection.CloseAsync();
                await _sqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<Response<List<Employee>>> ReadEmployeeById(int id)
        {
            Response<List<Employee>> response = new Response<List<Employee>>();
            List<Employee> employees = new List<Employee>();
            response.Status = Const.OK;
            response.Message = "Successful";
            try
            {
                if (_sqlConnection != null)
                {
                    string sqlQuery = "SELECT * FROM Employees WHERE Id=@Id";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.Parameters.AddWithValue("@Id", id);
                        await _sqlConnection.OpenAsync();

                        using (SqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync())
                                {
                                    Employee employee = new Employee();
                                    employee.Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
                                    employee.FullName = reader["FullName"] != DBNull.Value ? Convert.ToString(reader["FullName"]) : String.Empty;
                                    employee.PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? Convert.ToString(reader["PhoneNumber"]) : String.Empty;
                                    employee.Designation = reader["Designation"] != DBNull.Value ? Convert.ToString(reader["Designation"]) : String.Empty;
                                    employee.Email = reader["Email"] != DBNull.Value ? Convert.ToString(reader["Email"]) : String.Empty;

                                    employees.Add(employee);
                                }
                            }
                        }
                    }
                }

                response.ResponseBody = employees;

            }
            catch (Exception ex)
            {
                response.Status = Const.Error;
                response.Message = "Exception Message : " + ex.Message;
            }
            finally
            {
                await _sqlConnection.CloseAsync();
                await _sqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<Response<Employee>> UpdateEmployee(int id, Employee employee)
        {
            Response<Employee> response = new Response<Employee>();
            response.Status = Const.OK;
            response.Message = "Successful";
            try
            {
                if (_sqlConnection != null)
                {
                    string sqlQuery = "UPDATE Employees SET FullName=@FullName, Designation=@Designation, PhoneNumber=@PhoneNumber, Email=@Email WHERE Id=@Id";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = ConnectionTimeOut;
                        sqlCommand.Parameters.AddWithValue("@Id", id);
                        sqlCommand.Parameters.AddWithValue("@FullName", employee.FullName);
                        sqlCommand.Parameters.AddWithValue("@Designation", employee.Designation);
                        sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                        sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
                        await _sqlConnection.OpenAsync();

                        int Status = await sqlCommand.ExecuteNonQueryAsync();
                        if (Status <= 0)
                        {
                            response.Status = Const.Error;
                            response.Message = "Update Employee Not Executed";
                        }
                        else
                        {
                            response.ResponseBody = employee;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                response.Status = Const.Error;
                response.Message = "Exception Message : " + ex.Message;
            }
            finally
            {
                await _sqlConnection.CloseAsync();
                await _sqlConnection.DisposeAsync();
            }

            return response;
        }
    }
}
