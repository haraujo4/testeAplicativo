namespace BLL.DTO;

public class AtendimentoDTO
{
    public Guid Id { get; set; }
    public int NumeroSequencial { get; private set; }
    public Guid PacienteId { get; set; }
    public DateTime DataHoraChegada { get; set; }
    public bool Status { get; set; }
}


public class CreateAtentimentoDTO
{
    public Guid PacienteId { get; set; }
    public DateTime DataHoraChegada { get; set; }
    public bool Status { get; set; }
}

public class UpdateAtentimentoDTO
{
    public Guid PacienteId { get; set; }
    public DateTime DataHoraChegada { get; set; }
    public bool Status { get; set; }
}

