namespace API.Responses;

public class ApiResponseMetaData
{
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
    public int TotalPages { get; init; }
    public string? Text { get; init; }
}
