

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

            CreateMap<Veiculo, BuscaTodosVeiculosOutputBindingModel>()
            .ForMember(dest => dest.TipoVeiculo, opt => opt.MapFrom(src => src.TipoVeiculo.ToString()))
            .ForMember(dest => dest.Localizacao, opt => opt.MapFrom(src => src.Localizacao.Latitude.ToString().Replace(",",".")+","+src.Localizacao.Longitude.ToString().Replace(",",".")));    
        }
    }
}