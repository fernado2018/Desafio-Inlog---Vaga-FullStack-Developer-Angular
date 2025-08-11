

using AutoMapper;
using Inlog.Desafio.Backend.Domain.Models.Utils;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;
using Inlog.Desafio.Backend.WebApi.Models.Veiculo;

namespace Inlog.Desafio.Backend.WebApi.Mapeamentos
{
    public class VeiculoProfile: Profile
    {
        public VeiculoProfile()
        {
            CreateMap<CriarVeiculoBindingModel, Veiculo>();
            CreateMap<CriarLocalizacaoBindigModel, Localizacao>();
        
            CreateMap<Veiculo, BuscaTodosVeiculosOutputBindingModel>();
            CreateMap<Localizacao,LocalizacaoOutputBindingModel>();

    
        }
    }
}