using Microsoft.AspNetCore.Mvc;
using SOFTFISIO.DATA.INTERFACE;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SOFTFISIO.WEB.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly IRepositoryAgendamento _agendamento;
        private readonly IRepositoryPaciente _paciente;
        private readonly IRepositoryFuncionario _funcionario;
        private readonly IRepositoryProcedimento _procedimento;
        private readonly IRepositorySala _sala;

        public AgendamentoController(
            IRepositoryAgendamento agendamento,
            IRepositoryPaciente paciente,
            IRepositoryFuncionario funcionario,
            IRepositoryProcedimento procedimento,
            IRepositorySala sala)
        {
            _agendamento = agendamento;
            _paciente = paciente;
            _funcionario = funcionario;
            _procedimento = procedimento;
            _sala = sala;
        }

        public IActionResult Index()
        {
            var lista = _agendamento.SelecionarTodosCompleto();

            return View(lista);
        }

        public IActionResult Create()
        {
            var vm = new AgendamentoViewModel();

            vm.Pacientes = _paciente.SelecionarTodos();

            vm.Funcionarios = _funcionario.SelecionarTodos();

            vm.Procedimentos = _procedimento.SelecionarTodos();

            vm.Salas = _sala.SelecionarTodos();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AgendamentoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                bool conflito =
                    _agendamento.ExisteConflitoHorario(
                        vm.Agendamento.IdFuncionario.Value,
                        vm.Agendamento.DataAtendimento.Value,
                        vm.Agendamento.HoraInicio.Value,
                        vm.Agendamento.HoraFim.Value);

                if (conflito)
                {
                    ModelState.AddModelError(
                        "",
                        "Funcionário já possui horário agendado.");
                }
                else
                {
                    _agendamento.Incluir(vm.Agendamento);

                    return RedirectToAction("Index");
                }
            }

            vm.Pacientes = _paciente.SelecionarTodos();
            vm.Funcionarios = _funcionario.SelecionarTodos();
            vm.Procedimentos = _procedimento.SelecionarTodos();
            vm.Salas = _sala.SelecionarTodos();

            return View(vm);
        }
    }
}
    
