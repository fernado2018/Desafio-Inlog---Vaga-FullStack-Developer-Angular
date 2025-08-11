
using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Application.Interfaces;
using Inlog.Desafio.Backend.Domain.Models.Utils;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;
using Inlog.Desafio.Backend.Domain.Repositories;
using Inlog.Desafio.Backend.Domain.Validacao;
using Microsoft.EntityFrameworkCore;


namespace Inlog.Desafio.Backend.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IValidador<Veiculo> _veiculoValidador;
        private readonly IValidador<Localizacao> _localizacaoValidador;
        public VeiculoService(IVeiculoRepository veiculoRepository, IValidador<Veiculo> veiculoValidador,IValidador<Localizacao>  localizacaoValidador)
        {
            _veiculoRepository = veiculoRepository;
            _veiculoValidador = veiculoValidador;
            _localizacaoValidador = localizacaoValidador;
        }
        public async Task<PagedOutput<Veiculo>> BuscarTodosOsVeiculoPaginados(string? filtro, TipoVeiculo TipoVeiculo, string orderBy, bool orderDesc, int page, int pageSize)
        {
           var query =   _veiculoRepository.BuscarTodos().Include(x => x.Localizacao).AsQueryable();

            if (filtro.EstaPreenchido())
            {
                filtro = PesquisaCoringa.PosicaoTermodaPesquisa(filtro, "E");
                query = query.Where(x => (EF.Functions.Like(x.Chassi.ToLower(), filtro))
                || (EF.Functions.Like(x.Placa.ToLower(), filtro))
                || (EF.Functions.Like(x.Cor.ToLower(), filtro)));
            }

            else if (TipoVeiculo == TipoVeiculo.Caminhao || TipoVeiculo == TipoVeiculo.Onibus)
            {
                query = query.Where(x => x.TipoVeiculo == TipoVeiculo);
            }


            query = orderBy switch
            {
                "localizacao" => query.OrderByWithDirection(t => t.Localizacao, orderDesc),
                "cor" => query.OrderByWithDirection(c => c.Cor, orderDesc),
                _ => query.OrderByWithDirection(ch => ch.Chassi, orderDesc),
            };

            return await query.GetPagedAsync(page, pageSize);
        }

        public async Task<long> Criar(Veiculo veiculo)
        {
            _veiculoValidador.ValidarRegrasNegocio(veiculo);
            _localizacaoValidador.ValidarRegrasNegocio(veiculo.Localizacao);
           
            await _veiculoRepository.AdicionarAsync(veiculo);
            return veiculo.Id;
        }
        
        

    }
}