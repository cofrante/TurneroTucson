namespace Domain.Pagination;

public class PagedResult<T>(IReadOnlyList<T> items, int totalCount, int pageNumber, int pageSize)
{
    public IReadOnlyList<T> Items { get; } = items;
    public int TotalCount { get; } = totalCount;
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}
