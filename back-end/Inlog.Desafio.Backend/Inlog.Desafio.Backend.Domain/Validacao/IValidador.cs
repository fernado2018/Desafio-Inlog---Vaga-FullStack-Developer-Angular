using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;

namespace Inlog.Desafio.Backend.Domain.Validacao
{
    public interface IValidador<T>
    {
        void ValidarRegrasNegocio(T localizacao);
    }
}