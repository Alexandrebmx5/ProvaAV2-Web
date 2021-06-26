using Dominio.Repositories;
using Historias.Veiculos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly CriarVeiculo criarVeiculo;
        private readonly AlterarVeiculo alterarVeiculo;
        private readonly RemoverVeiculo excluirVeiculo;
        private readonly ConsultarVeiculo consultasVeiculo;

        public VeiculoController(IVeiculosRepository veiculosRepository)
        {
            criarVeiculo = new CriarVeiculo(veiculosRepository);
            alterarVeiculo = new AlterarVeiculo(veiculosRepository);
            excluirVeiculo = new RemoverVeiculo(veiculosRepository);
            consultasVeiculo = new ConsultarVeiculo(veiculosRepository);
        }
        public async Task<IActionResult> Index()
        {
            var listaVeiculos = await consultasVeiculo.ListaTodosVeiculos();
            var listaVeiculosViewModel = VeiculosFactory.MapearListaVeiculosViewModel(listaVeiculos);

            return View(listaVeiculosViewModel);
        }

        public IActionResult Criar()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(VeiculoViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var veiculo = VeiculosFactory.MapearVeiculos(model);

                await criarVeiculo.Executar(veiculo);

                return RedirectToAction("Index");
            }


            return View(model);
        }

        public async Task<IActionResult> Alterar(int id)
        {
            var veiculo = await consultasVeiculo.BuscarPeloId(id);

            if (veiculo == null)
            {
                return RedirectToAction("Index");
            }

            var model = VeiculosFactory.MapearVeiculosViewModel(veiculo);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(veiculoViewModel);
            }

            var veiculo = VeiculosFactory.MapearVeiculos(veiculoViewModel);

            await alterarVeiculo.Executar(id, veiculo);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalhar(int id)
        {
            var veiculo = await consultasVeiculo.BuscarPeloId(id);

            if (veiculo == null)
            {
                return RedirectToAction("Index");
            }

            var model = VeiculosFactory.MapearVeiculosViewModel(veiculo);

            return View(model);
        }

        public async Task<IActionResult> Excluir(int id)
        {
            var veiculo = await consultasVeiculo.BuscarPeloId(id);

            if (veiculo == null)
            {
                return RedirectToAction("Index");
            }


            await excluirVeiculo.Executar(veiculo);

            return RedirectToAction("Index");
        }
    }
}
