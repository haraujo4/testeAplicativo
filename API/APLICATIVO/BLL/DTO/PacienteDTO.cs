namespace BLL.DTO;

public class PacienteDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public char Sexo { get; set; }
    public string Email { get; set; }
}


public class CreatePacienteDTO
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public char Sexo { get; set; }
    public string Email { get; set; }
}

public class UpdatePacienteDTO
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public char Sexo { get; set; }
    public string Email { get; set; }
}