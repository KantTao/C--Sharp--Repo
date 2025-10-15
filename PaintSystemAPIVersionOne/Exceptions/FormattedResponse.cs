namespace PaintSystemAPIVersionOne.Exceptions;

public class FormattedResponse<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public DateTime RequestTime { get; set; }
    public T? Data { get; set; }


    public FormattedResponse(string message, bool isSuccess, int statusCode, T? data = default)
    {
        Message = message;
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Data = data;
        RequestTime = DateTime.Now;
    }

    public static FormattedResponse<T> Success(T data, string message = "Success")
    {
        return new FormattedResponse<T>(message, true, 200, data);
    }

    public static FormattedResponse<T> Fail(string message, int statusCode = 400)
    {
        return new FormattedResponse<T>(message, false, statusCode);
    }
}