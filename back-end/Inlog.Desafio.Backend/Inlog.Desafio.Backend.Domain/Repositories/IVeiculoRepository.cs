using Inlog.Desafio.Backend.Domain.Models.Veiculo;

namespace Inlog.Desafio.Backend.Domain.Repositories
{
    public interface IVeiculoRepository
    {
        Task AdicionarAsync(Veiculo veiculo);
        IQueryable<Veiculo> BuscarTodos();
    }
}