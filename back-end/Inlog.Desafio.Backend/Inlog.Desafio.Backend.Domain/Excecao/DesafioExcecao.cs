using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlog.Desafio.Backend.Domain.Excecao
{
    public class DesafioExcecao: Exception
    {
        public DesafioExcecao(string mensage): base(mensage)
        {
            
        }
    }
}