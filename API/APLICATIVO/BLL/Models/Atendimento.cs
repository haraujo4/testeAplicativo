namespace BLL.Models;

public class Atendimento
{
    public Guid Id { get; set; }
    public int NumeroSequencial { get; private set; }
    public Guid PacienteId { get; set; }
    public DateTime DataHoraChegada { get; set; }
    public bool Status { get; set; }

    public Paciente Paciente { get; set; }

    public Triagem Triagem { get; set; }

    public Atendimento(Guid pacienteId, DateTime dataHoraChegada, bool status)
    {
        Id = Guid.NewGuid();
        PacienteId = pacienteId;
        DataHoraChegada = dataHoraChegada;
        Status = status;
    }
}