namespace Ambev.DeveloperEvaluation.Domain.Common;

public interface IPaginatedList<T>
{
    IEnumerable<T> Items { get; }
    int CurrentPage { get; }
    int TotalPages { get; }
    int PageSize { get; }
    int TotalCount { get; }
    bool HasPrevious { get; }
    bool HasNext { get; }
}