using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;
using Inlog.Desafio.Backend.Domain.Repositories;
using Inlog.Desafio.Backend.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Inlog.Desafio.Backend.Infra.Database.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly InlogDbContext _context;

        public VeiculoRepository(InlogDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Veiculo veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Veiculo> BuscarTodos()
        {
            IQueryable<Veiculo> query = _context.Veiculos.AsNoTracking();
            return query;
        }
    }
}