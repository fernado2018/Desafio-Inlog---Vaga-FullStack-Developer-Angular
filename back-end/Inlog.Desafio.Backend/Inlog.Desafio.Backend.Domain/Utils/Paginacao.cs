using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Inlog.Desafio.Backend.Domain.Models.Utils
{
    public static class Paginacao
    { 
        public static async Task<PagedOutput<T>> GetPagedAsync<T>(this IQueryable<T> query, int page, int pageSize = 5) where T : class
        {
            var result = new PagedOutput<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = await query.CountAsync(),
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}