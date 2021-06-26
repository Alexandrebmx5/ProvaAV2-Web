using Dominio.Entidades;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias.Veiculos
{
    public class CriarVeiculo
    {
        private readonly IVeiculosRepository _veiculosRepository;

        public CriarVeiculo(IVeiculosRepository veiculosRepository)
        {
            _veiculosRepository = veiculosRepository;
        }

        public async Task Executar(Veiculo veiculo)
        {
            await _veiculosRepository.Criar(veiculo);
        }
    }
}
