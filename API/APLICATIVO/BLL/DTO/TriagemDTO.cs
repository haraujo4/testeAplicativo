namespace BLL.DTO;

public class TriagemDTO
{
    public Guid Id { get; set; }
    public Guid AtendimentoId { get; set; }
    public string Sintomas { get; set; }
    public string PressaoArterial { get; set; }
    public decimal Peso { get; set; }
    public int Altura { get; set; }
    public Guid EspecialidadeId { get; set; }
}

public class CreateTriagemDTO
{
    public Guid AtendimentoId { get; set; }
    public string Sintomas { get; set; }
    public string PressaoArterial { get; set; }
    public decimal Peso { get; set; }
    public int Altura { get; set; }
    public Guid EspecialidadeId { get; set; }
}

public class UpdateTriagemDTO
{
    public Guid AtendimentoId { get; set; }
    public string Sintomas { get; set; }
    public string PressaoArterial { get; set; }
    public decimal Peso { get; set; }
    public int Altura { get; set; }
    public Guid EspecialidadeId { get; set; }
}