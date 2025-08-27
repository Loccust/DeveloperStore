using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.WebApi.Common;

public class PaginatedList<T> : IPaginatedList<T>
{
    public IEnumerable<T> Items { get; private set; }
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        Items = items;
    }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, string? orderBy = null)
    {
        source = ApplyOrdering(source, orderBy);

        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }

    private static IQueryable<T> ApplyOrdering(IQueryable<T> source, string? orderBy)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
            return source;

        IOrderedQueryable<T>? orderedQuery = null;

        foreach (var order in orderBy.Split(','))
        {
            var parts = order.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var propertyName = parts[0];
            var descending = parts.Length > 1 && parts[1].ToLower() == "desc";

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, propertyName);
            var lambda = Expression.Lambda(property, parameter);

            string methodName;

            if (orderedQuery == null)
                methodName = descending ? "OrderByDescending" : "OrderBy";
            else
                methodName = descending ? "ThenByDescending" : "ThenBy";

            var resultExp = Expression.Call(
                typeof(Queryable),
                methodName,
                [typeof(T), property.Type],
                (orderedQuery ?? source).Expression,
                Expression.Quote(lambda)
            );

            orderedQuery = (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(resultExp);
        }

        return orderedQuery ?? source;
    }
}