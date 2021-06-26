using Dominio.Entidades;
using Dominio.Repositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class VeiculosRepository : IVeiculosRepository
    {
        private readonly DataContext _dataContext;

        public VeiculosRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Alterar(Veiculo veiculos)
        {
            _dataContext.Update(veiculos);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Criar(Veiculo veiculos)
        {
            _dataContext.veiculos.Add(veiculos);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Excluir(Veiculo veiculos)
        {
            _dataContext.Remove(veiculos);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Veiculo> BuscarPorId(int id)
        {
            var veiculos = await _dataContext.veiculos.FirstOrDefaultAsync(x => x.Id == id);
            return veiculos;
        }

        public async Task<IEnumerable<Veiculo>> ListarTodosOsVeiculos()
        {
            return await _dataContext.veiculos.AsNoTracking().ToListAsync();
        }
    }
}
