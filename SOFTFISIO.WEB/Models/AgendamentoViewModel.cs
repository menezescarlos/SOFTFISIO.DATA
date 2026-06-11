using Microsoft.AspNetCore.Mvc.Rendering;
using SOFTFISIO.DATA.Models;

public class AgendamentoViewModel
{
    public Agendamento Agendamento { get; set; }

    public List<Paciente> Pacientes { get; set; }

    public List<Funcionario> Funcionarios { get; set; }

    public List<Procedimento> Procedimentos { get; set; }

    public List<Sala> Salas { get; set; }
}