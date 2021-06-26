using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Factories
{
    public class VeiculosFactory
    {
        public static VeiculoViewModel MapearVeiculosViewModel(Veiculo veiculos)
        {
            var veiculoViewModel = new VeiculoViewModel
            {
                Id = veiculos.Id,
                Marca = veiculos.Marca,
                Modelo = veiculos.Modelo,
                Ano = veiculos.Ano,
                Quilometragem = veiculos.Quilometragem
            };

            return veiculoViewModel;
        }

        public static Veiculo MapearVeiculos(VeiculoViewModel veiculoViewModel)
        {
            var veiculos = new Veiculo(
                veiculoViewModel.Marca,
                veiculoViewModel.Modelo,
                veiculoViewModel.Ano,
                veiculoViewModel.Quilometragem
                );

            return veiculos;
        }

        public static IEnumerable<VeiculoViewModel> MapearListaVeiculosViewModel(IEnumerable<Veiculo> veiculos)
        {
            var lista = new List<VeiculoViewModel>();
            foreach (var item in veiculos)
            {
                lista.Add(MapearVeiculosViewModel(item));
            }
            return lista;
        }
    }
}
