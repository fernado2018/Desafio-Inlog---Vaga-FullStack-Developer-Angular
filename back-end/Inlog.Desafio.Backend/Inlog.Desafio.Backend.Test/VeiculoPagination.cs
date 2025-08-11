using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlog.Desafio.Backend.Application.Services;
using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;
using Inlog.Desafio.Backend.Domain.Repositories;
using Inlog.Desafio.Backend.Domain.Validacao;
using Moq;
using Shouldly;
using Xunit;

namespace Inlog.Desafio.Backend.Test
{
    public class VeiculoPagination
    {
        [Fact]
        public async Task BuscarTodosOsVeiculoPaginados_DeveFiltrarPorTipoVeiculo()
        {
             // Arrange
             var veiculos = new List<Veiculo>
             {
                 new Veiculo { Id = 1, Chassi = "ABC123", Cor = "Azul", TipoVeiculo = TipoVeiculo.Caminhao, Localizacao = new Localizacao() },
                 new Veiculo { Id = 2, Chassi = "DEF456", Cor = "Vermelho", TipoVeiculo = TipoVeiculo.Onibus, Localizacao = new Localizacao() },
                 new Veiculo { Id = 3, Chassi = "GHI789", Cor = "Verde", TipoVeiculo = TipoVeiculo.Caminhao, Localizacao = new Localizacao() }
             }.AsQueryable();
     
             var repoMock = new Mock<IVeiculoRepository>();
             repoMock.Setup(r => r.BuscarTodos()).Returns(veiculos);
     
             var validadorVeiculoMock = new Mock<IValidador<Veiculo>>();
             var validadorLocalizacaoMock = new Mock<IValidador<Localizacao>>();
     
             var service = new VeiculoService(repoMock.Object, validadorVeiculoMock.Object, validadorLocalizacaoMock.Object);
     
             // Act
             var result = await service.BuscarTodosOsVeiculoPaginados(null, TipoVeiculo.Caminhao, "chassi", false, 1, 10);
     
             // Assert
             result.Results.Count.ShouldBe(2);
             result.Results.All(v => v.TipoVeiculo == TipoVeiculo.Caminhao).ShouldBeTrue();
         }
     
    }
}