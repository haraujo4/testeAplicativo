using BLL.DTO;
using BLL.Models;

namespace BLL.Interface.Services;

public interface IPacienteServices
{
    Task<IEnumerable<PacienteDTO>> GetAllPacientesAsync();
    Task<PacienteDTO> GetPacienteByIdAsync(Guid id);
    Task<PacienteDTO> AddPacienteAsync(CreatePacienteDTO paciente);
    Task<PacienteDTO> UpdatePacienteAsync(Guid id, UpdatePacienteDTO paciente);
    Task<PacienteDTO> GetByEmailAsync(string email);
    Task<bool> DeletePacienteAsync(Guid id);
}