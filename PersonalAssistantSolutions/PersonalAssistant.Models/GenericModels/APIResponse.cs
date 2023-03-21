namespace PersonalAssistant.Models.GenericModels;

public class APIResponse<T> where T : class
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }

    public static APIResponse<T> Success(T data)
    {
        return new APIResponse<T>
        {
            Data = data,
            IsSuccess = true,
        };
    }

    public static APIResponse<T> Failed(string message)
    {
        return new APIResponse<T>
        {
            IsSuccess = false,
            Message = string.IsNullOrEmpty(message) ? $"{nameof(Failed)}" : message
        };
    }
}
