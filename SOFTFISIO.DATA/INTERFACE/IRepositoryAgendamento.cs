using SOFTFISIO.DATA.Models;

namespace SOFTFISIO.DATA.INTERFACE
{
    public interface IRepositoryAgendamento : IRepositoryModel<Agendamento>
    {
        List<Agendamento> SelecionarTodosCompleto();

        bool ExisteConflitoHorario(
            int funcionario,
            DateOnly data,
            TimeOnly inicio,
            TimeOnly fim);
    }
}
