
using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;
using Inlog.Desafio.Backend.Domain.Repositories;
using Xunit;
using Moq;
using Inlog.Desafio.Backend.Domain.Validacao;
using Inlog.Desafio.Backend.Application.Services;
using Shouldly;
namespace Inlog.Desafio.Backend.Test
{
    public class AoCriarVeiculo
    {
         [Fact]
         public async Task Criar_DeveValidarEVeiculoESalvar()
         {
               // Arrange
               var veiculo = new Veiculo
               {
                   Id = 1,
                   Chassi = "123ABC",
                   Cor = "Azul",
                   TipoVeiculo = TipoVeiculo.Caminhao,
                   Placa= "AAA-9A99",
                   NumeroSerieRastreador = "A0000000",
                   Localizacao = new Localizacao { Latitude = 10, Longitude = 20 }
               };
       
             var veiculoRepoMock = new Mock<IVeiculoRepository>();
             var veiculoValidadorMock = new Mock<IValidador<Veiculo>>();
             var localizacaoValidadorMock = new Mock<IValidador<Localizacao>>();
     
             var service = new VeiculoService(veiculoRepoMock.Object, veiculoValidadorMock.Object, localizacaoValidadorMock.Object);
     
             // Act
             var result = await service.Criar(veiculo);
     
             // Assert
             veiculoValidadorMock.Verify(v => v.ValidarRegrasNegocio(veiculo), Times.Once);
             localizacaoValidadorMock.Verify(v => v.ValidarRegrasNegocio(veiculo.Localizacao), Times.Once);
             veiculoRepoMock.Verify(r => r.AdicionarAsync(veiculo), Times.Once);
     
             result.ShouldBe(veiculo.Id);

         }


    }
}