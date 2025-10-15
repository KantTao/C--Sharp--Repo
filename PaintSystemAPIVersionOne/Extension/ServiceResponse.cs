namespace PaintSystemAPIVersionOne.Extension;

public class ServiceResponse<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }   // ✅ 改成可空

    public ServiceResponse()
    {
    }
    
    public ServiceResponse(bool success, string message, T data)
    {
        IsSuccess = success;
        Message = message;
        Data = data;
    }
}