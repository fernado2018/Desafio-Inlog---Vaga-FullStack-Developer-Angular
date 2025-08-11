using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inlog.Desafio.Backend.Domain.Models.Utils
{
    public static class OderByQuery
    {
        public static IOrderedQueryable<TSource> OrderByWithDirection<TSource, TKey>(this IQueryable<TSource> source, 
                                                                                    Expression<Func<TSource, TKey>> keySelector, 
                                                                                    bool descending)
    {
        return descending ? source.OrderByDescending(keySelector)
                            : source.OrderBy(keySelector);
    }
    }
}