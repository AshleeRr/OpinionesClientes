
namespace OpinionesClientes.Application.Results
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        private ServiceResult(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }

        public static ServiceResult Success(string message) => new(true, message);
        public static ServiceResult Failure(string message) => new(false, message);
    }
}
