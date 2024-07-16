namespace EmployeeManagement.Services
{
    public class JsonResponseService : IJsonResponseService
    {
        public object GenerateJsonResponse()
        {
            return new
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Message = "This is a JSON response."
            };
        }
    }
}
