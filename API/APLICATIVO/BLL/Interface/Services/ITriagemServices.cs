using BLL.DTO;

namespace BLL.Interface.Services;

public interface ITriagemServices
{
    Task<IEnumerable<TriagemDTO>> GetAllAsync();
    Task<TriagemDTO> GetByIdAsync(Guid id);
    Task<TriagemDTO> CreateAsync(CreateTriagemDTO triagemDTO);
    Task<TriagemDTO> UpdateAsync(Guid id, UpdateTriagemDTO triagemDTO);
    Task<bool> DeleteAsync(Guid id);
}