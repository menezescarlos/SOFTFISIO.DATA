using Microsoft.EntityFrameworkCore;
using SOFTFISIO.DATA.INTERFACE;
using SOFTFISIO.DATA.Models;

namespace SOFTFISIO.DATA.REPOSITORY
{
    public class RepositoryAgendamento
    : RepositoryBase<Agendamento>, IRepositoryAgendamento
    {
        public RepositoryAgendamento()
            : base()
        {
        }

        public List<Agendamento> SelecionarTodosCompleto()
        {
            return _DATAFISIOContexto.Agendamentos
                .Include(a => a.IdPacienteNavigation)
                .Include(a => a.IdFuncionarioNavigation)
                .Include(a => a.IdProcedimentoNavigation)
                .Include(a => a.IdEmpresaNavigation)
                .ToList();
        }

        public bool ExisteConflitoHorario(
            int funcionario,
            DateOnly data,
            TimeOnly inicio,
            TimeOnly fim)
        {
            return _DATAFISIOContexto.Agendamentos.Any(a =>
                a.IdFuncionario == funcionario
                && a.DataAtendimento == data
                && a.HoraInicio.HasValue
                && a.HoraFim.HasValue
                && inicio < a.HoraFim.Value
                && fim > a.HoraInicio.Value);
        }
    }
}