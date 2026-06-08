using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOFTFISIO.DATA.INTERFACE;
using SOFTFISIO.DATA.Models;


namespace SOFTFISIO.WEB.Controllers
{
    public class EmpresaController : Controller
    {
        // Campo para o repositório de Contrato
        private readonly IRepositoryEmpresa _repository;

        // Injeção de dependência do repositório
        public EmpresaController(IRepositoryEmpresa repository)
        {
            // Atribui o repositório injetado ao campo local
            _repository = repository;
        }
        public IActionResult Index()
        {
            var empresa = _repository.SelecionarTodos();

            return View(empresa);
        }

        // GET
        // Ação para exibir o formulário de criação de um novo contrato
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST: Unidade/Create
        public IActionResult Create(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _repository.Incluir(empresa);

                return RedirectToAction(nameof(Index));
            }

            return View(empresa);
        }

        // GET
        public IActionResult Edit(int id)
        {
            var empresa = _repository.SelecionarPorPK(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        [HttpPost]
        // Ação para processar o formulário de edição de um contrato existente
        public IActionResult Edit(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _repository.Alterar(empresa);

                return RedirectToAction(nameof(Index));
            }

            return View(empresa);
        }


        // GET
        public IActionResult Delete(int id)
        {
            var empresa = _repository.SelecionarPorPK(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        [HttpPost]
        // Ação para processar a confirmação de exclusão de um contrato
        public IActionResult DeleteConfirmed(int IdEmpresa)
        {
            _repository.Exclusao(IdEmpresa);

            return RedirectToAction(nameof(Index));
        }

    }
}
