using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlog.Desafio.Backend.Domain.Models.Utils
{
   public class PagedOutput<T> : PagedOutputBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedOutput()
        {
            Results = new List<T>();
        }
    }
}