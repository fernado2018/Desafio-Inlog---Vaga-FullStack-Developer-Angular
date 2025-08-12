using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Domain.Models.Utils;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;

namespace Inlog.Desafio.Backend.Application.Interfaces
{
    public interface IVeiculoService
    {
         Task<long> Criar(Veiculo veiculo);
        Task<PagedOutput<Veiculo>> BuscarTodosOsVeiculoPaginados(string? filtro, string orderBy, bool orderDesc, int page, int pageSize);

    }
}