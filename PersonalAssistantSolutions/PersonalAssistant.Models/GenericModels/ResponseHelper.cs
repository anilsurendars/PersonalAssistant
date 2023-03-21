namespace PersonalAssistant.Models.GenericModels;

public static class ResponseHelper
{
    public static APIResponse<T> GetResponse<T>(this T data) where T : class
    {
        return APIResponse<T>.Success(data);
    }

    public static APIResponse<T> GetFailedResponse<T>(this T data, string message) where T : class
    {
        return APIResponse<T>.Failed(message);
    }

    public static APIResponse<T> GetFailedResponse<T>(this string message) where T : class
    {
        return APIResponse<T>.Failed(message);
    }
}
