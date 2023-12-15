namespace EmployeeManagmentPortal.Commons.Model
{
    public class Response<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T ResponseBody { get; set; }
    }
}
