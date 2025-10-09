namespace BookManagementSystemAPI.Exceptions;

public class FormattedResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public DateTime RequestTime { get; set; }
    
    
    public FormattedResponse(string message, bool isSuccess, int statusCode)
    {
        StatusCode = statusCode;
        Message = message;
        IsSuccess = isSuccess;
        RequestTime = DateTime.Now;
    }
}