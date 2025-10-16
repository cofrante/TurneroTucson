namespace API.Responses;

public class ApiResponse<T>
    where T : class
{
    public T? Data { get; init; }
    public ApiResponseMetaData? Meta { get; init; }
}