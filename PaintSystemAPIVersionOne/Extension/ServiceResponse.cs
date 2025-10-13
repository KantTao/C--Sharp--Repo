namespace PaintSystemAPIVersionOne.Extension;

public class ServiceResponse<T>
{
    public bool IsSuccess { get; set; }      // 业务是否成功
    public string Message { get; set; }      // 提示信息
    public T Data { get; set; }              // 返回数据
    
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