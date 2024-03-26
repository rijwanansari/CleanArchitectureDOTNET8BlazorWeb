namespace Application.Common.Model;

public class ResponseModel<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T? Output { get; set; }

    public static ResponseModel<T> SuccessResponse(string message, T output)
    {
        return new ResponseModel<T>
        {
            Success = true,
            Message = message,
            Output = output
        };
    }
    public static ResponseModel<T> FailureResponse(string message)
    {
        return new ResponseModel<T>
        {
            Success = false,
            Message = message
        };
    }

}