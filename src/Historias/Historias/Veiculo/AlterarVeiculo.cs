using Dominio.Entidades;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias.Veiculos
{
    public class AlterarVeiculo
    {
        private readonly IVeiculosRepository _veiculosRepository;

        public AlterarVeiculo(IVeiculosRepository veiculosRepository)
        {
            _veiculosRepository = veiculosRepository;
        }

        public async Task Executar(int id, Veiculo veiculo)
        {
            var dadosVeiculo = await _veiculosRepository.BuscarPorId(id);

            dadosVeiculo.AtualizarVeiculo(veiculo.Marca, veiculo.Modelo, veiculo.Ano, veiculo.Quilometragem);

            await _veiculosRepository.Alterar(dadosVeiculo);
        }
    }
}
