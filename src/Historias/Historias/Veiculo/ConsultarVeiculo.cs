using Dominio.Entidades;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias.Veiculos
{
    public class ConsultarVeiculo
    {
        private readonly IVeiculosRepository _veiculosRepository;

        public ConsultarVeiculo(IVeiculosRepository veiculosRepository)
        {
            _veiculosRepository = veiculosRepository;
        }

        public async Task<Veiculo> BuscarPeloId(int id)
        {
            return await _veiculosRepository.BuscarPorId(id);
        }

        public async Task<IEnumerable<Veiculo>> ListaTodosVeiculos()
        {
            return await _veiculosRepository.ListarTodosOsVeiculos();
        }
    }
}
