using Dominio.Entidades;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias.Veiculos
{
    public class RemoverVeiculo
    {
        private readonly IVeiculosRepository _veiculosRepository;

        public RemoverVeiculo(IVeiculosRepository veiculosRepository)
        {
            _veiculosRepository = veiculosRepository;
        }

        public async Task Executar(Veiculo veiculo)
        {
            await _veiculosRepository.Excluir(veiculo);
        }
    }
}
