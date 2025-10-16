using Domain.Pagination;

namespace API.Responses;

public static class ApiResponseExtensions
{
    public static ApiResponseMetaData ToMetaData<T>(this PagedResult<T> result)
        => new()
        {
            Page = result.PageNumber,
            PageSize = result.PageSize,
            TotalCount = result.TotalCount,
            TotalPages = result.TotalPages
        };

    public static ApiResponse<IEnumerable<T>> ToApiResponse<T>(this PagedResult<T> result)
        => new()
        {
            Data = result.Items,
            Meta = result.ToMetaData()
        };
}
