using CMS.Domain.Interfaces;

namespace CMS.Application.Extensions.IQueryableExtensions
{
    public static class IRemoveAtExtensions
    {
        public static IQueryable<T> NotRemoved<T>(this IQueryable<T> query) where T : IRemovedAt
        {
            return query.Where(x => !x.EndDate.HasValue);
        }
    }
}
