using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlog.Desafio.Backend.Domain.Excecao;
using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;

namespace Inlog.Desafio.Backend.Domain.Validacao
{
    public class VeiculoValidador : IValidador<Veiculo>
    {
        public void ValidarRegrasNegocio(Veiculo veiculo)
        {
            ValidarCampoObrigatorio(veiculo.Chassi, "chassi");
            ValidarCampoObrigatorio(veiculo.TipoVeiculo.ToString(), "tipo de veiculo");
            ValidarCampoObrigatorio(veiculo.Cor, "cor");
            ValidarCampoObrigatorio(veiculo.Placa, "placa");
            ValidarCampoObrigatorio(veiculo.NumeroSerieRastreador, "número de série do rastreador");
            
        }

        private void ValidarCampoObrigatorio(string valor, string nomeCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new DesafioExcecao($"O campo {nomeCampo} deve ser preenchido.");
        }

    }
}