namespace Ambev.DeveloperEvaluation.Application.Common;

public class PaginatedResult<T>
{
    public IEnumerable<T> Items { get; private set; }
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int TotalCount { get; private set; }
}
