using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;

namespace Inlog.Desafio.Backend.WebApi.Models.Veiculo
{
    public class BuscaTodosVeiculosOutputBindingModel
    {
        public long Id { get; set; }
        public string Chassi { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public string Cor { get; set; }
        public string Placa{ get; set; }
        public string NumeroSerieRastreador{ get; set; }
        public LocalizacaoOutputBindingModel Localizacao { get; set; }
    }
}