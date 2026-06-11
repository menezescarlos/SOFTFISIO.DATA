using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOFTFISIO.DATA.INTERFACE;
using SOFTFISIO.DATA.Models;
using SOFTFISIO.DATA.REPOSITORY;

namespace SOFTFISIO.WEB.Controllers
{
    public class CooperativaController : Controller
    {
        // Campo privado para armazenar a instância do repositório de Empresa,
        // que será utilizado para realizar as operações de banco de dados relacionadas à entidade Empresa.
        private readonly IRepositoryCooperativa _repositoryCooperativa;
        private readonly IRepositoryEmpresa _repositoryEmpresa;

        // Injeção de dependência do repositório
        public CooperativaController(IRepositoryCooperativa repositoryCooperativa,
            IRepositoryEmpresa repositoryEmpresa)
        {
            _repositoryCooperativa = repositoryCooperativa;
            _repositoryEmpresa = repositoryEmpresa;
        }
        public IActionResult Index()
        {
            var cooperativa = _repositoryCooperativa
             .SelecionarTodosComCooperativa();

            return View(cooperativa);
        }

        // GET
        // Ação para exibir o formulário de criação de um nova Empresa
        public IActionResult Create()
        {
            ViewBag.Empresas = _repositoryEmpresa
               .SelecionarTodos()
               .Select(c => new SelectListItem
               {
                   Value = c.IdEmpresa.ToString(),
                   Text = $"{c.IdEmpresa} - {c.NomeFantasia}"
               })
               .ToList();

            return View();
        }

        [HttpPost]
        // POST: Unidade/Create
        public IActionResult Create(Cooperativa cooperativa)
        {

            if (ModelState.IsValid)
            {
                _repositoryCooperativa.Incluir(cooperativa);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Empresas = _repositoryEmpresa
                .SelecionarTodos()
                .Select(x => new SelectListItem
                {
                    Value = x.IdEmpresa.ToString(),
                    Text = $"{x.IdEmpresa} - {x.NomeFantasia}"
                })
                .ToList();

            return View(cooperativa);
        }

        // GET
        // Ação para exibir o formulário de edição de um contrato existente, identificando-o por sua chave primária (PK)
        public IActionResult Edit(int id)
        {
            var cooperativa = _repositoryCooperativa.SelecionarPorPK(id);

            if (cooperativa == null)
            {
                return NotFound();
            }

            return View(cooperativa);
        }

        [HttpPost]
        // Ação para processar o formulário de edição de um contrato existente,
        // identificando-o por sua chave primária (PK)
        public IActionResult Edit(Cooperativa cooperativa)
        {
            if (ModelState.IsValid)
            {
                _repositoryCooperativa.Alterar(cooperativa);

                return RedirectToAction(nameof(Index));
            }

            return View(cooperativa);
        }

        // GET
        public IActionResult Delete(int id)
        {
            var cooperativa = _repositoryCooperativa.SelecionarPorPK(id);

            if (cooperativa == null)
            {
                return NotFound();
            }

            return View(cooperativa);
        }

        [HttpPost]
        // Ação para processar a exclusão de um contrato existente, identificando-o por sua chave primária (PK)
        public IActionResult DeleteConfirmed(int IdCooperativa)
        {
            _repositoryCooperativa.Exclusao(IdCooperativa);

            return RedirectToAction(nameof(Index));
        }

        // GET
        public IActionResult Details(int id)
        {
            Cooperativa cooperativa = _repositoryCooperativa.SelecionarPorPK(id);

            if (cooperativa == null)
            {
                return NotFound();
            }

            return View(cooperativa);
        }
    }
}
