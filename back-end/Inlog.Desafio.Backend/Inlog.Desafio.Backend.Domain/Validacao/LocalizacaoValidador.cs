using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlog.Desafio.Backend.Domain.Excecao;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;
using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Domain.Validacao
{
    public class LocalizacaoValidador : IValidador<Localizacao>
    {
        public void ValidarRegrasNegocio(Localizacao localizacao)
        {
           validaLatitude(localizacao.Latitude);
           validaLogitude(localizacao.Longitude);
        }


        private void validaLatitude(double latitude)
        {
            if (latitude == 0 && latitude >= -90  && latitude <= 90) 
            {
                throw new DesafioExcecao("O campo Latitude deve ser preenchido.");
            }

        }
        
         private void validaLogitude(double longitude)
        {
            if (longitude == 0 && longitude >= -180  && longitude <= 180)
            {
                throw new DesafioExcecao("O campo Longitude deve ser preenchido.");
            }

        }
    }
}