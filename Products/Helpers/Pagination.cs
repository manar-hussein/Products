using Microsoft.EntityFrameworkCore;

namespace Products.Helpers
{
    public static class Pagination
    {
        public static async Task<PaginationResult<T>> Paginate<T>(this IQueryable<T> values, int index, int size = 5)
        {
            var result = new PaginationResult<T>();
            result.TotalRecords = await values.CountAsync();
            result.CurrentPage = index > 0 ? index : 1;
            result.Size = size > 0 && size < result.TotalRecords ? size : result.TotalRecords;
            result.TotalPages = (int)Math.Ceiling(((decimal)result.TotalRecords / result.Size));
            var numberOfExcluded = (result.CurrentPage - 1) * size;
            result.values = await values.Skip(numberOfExcluded).Take(size).ToListAsync();
            return result;
        }
    }
}
