using BLL.DTO;

namespace BLL.Interface.Services;

public interface IEspecialidadeServices
{
    Task<IEnumerable<EspecialidadeDTO>> GetAllAsync();
    Task<EspecialidadeDTO> GetByIdAsync(Guid id);
    Task<EspecialidadeDTO> GeyByEspecialidadeAsync(string especialidade);
}