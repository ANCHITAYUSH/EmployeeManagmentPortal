namespace EmployeeManagmentPortal.Commons.Model
{
    public class Request<T>
    {
        public int Id { get; set; }
        public T RequestBody { get; set; }
    }
}
