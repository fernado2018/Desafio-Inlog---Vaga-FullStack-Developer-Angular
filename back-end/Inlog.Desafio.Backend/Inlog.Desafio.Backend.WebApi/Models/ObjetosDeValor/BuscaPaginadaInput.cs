using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlog.Desafio.Backend.WebApi.Models.ObjetosDeValor
{
    public abstract class BuscaPaginadaInput
    {
        public string? Filtro { get; set; }
        public bool OrderDesc { get; set; } = true;
        public string OrderBy { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}