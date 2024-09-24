namespace BLL.Models;

public class Triagem
{
    public Guid Id { get; set; }
    public Guid AtendimentoId { get; set; }
    public string Sintomas { get; set; }
    public string PressaoArterial { get; set; }
    public decimal Peso { get; set; }
    public int Altura { get; set; }
    public Guid EspecialidadeId { get; set; }

    public Atendimento Atendimento { get; set; }

    public Triagem(Guid atendimentoId, string sintomas, string pressaoArterial, decimal peso, int altura, Guid especialidadeId)
    {
        Id = Guid.NewGuid();
        AtendimentoId = atendimentoId;
        Sintomas = sintomas;
        PressaoArterial = pressaoArterial;
        Peso = peso;
        Altura = altura;
        EspecialidadeId = especialidadeId;
    }
}