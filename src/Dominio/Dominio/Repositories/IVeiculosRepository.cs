using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositories
{
    public interface IVeiculosRepository
    {
        Task Criar(Veiculo veiculos);
        Task Alterar(Veiculo veiculos);
        Task Excluir(Veiculo veiculos);
        Task<Veiculo> BuscarPorId(int id);
        Task<IEnumerable<Veiculo>> ListarTodosOsVeiculos();
    }
}
