namespace BLL.Models;

public class Paciente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public char Sexo { get; set; }
    public string Email { get; set; }
        
    public ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

    public Paciente(string nome, string telefone, char sexo, string email)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Telefone = telefone;
        Sexo = sexo;
        Email = email;
    }
}