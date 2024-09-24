using BLL.DTO;

namespace BLL.Interface.Services;

public interface IAtendimentoServices
{
    Task<IEnumerable<AtendimentoDTO>> GetAllAsync();
    Task<AtendimentoDTO> GetByIdAsync(Guid id);
    Task<AtendimentoDTO> AddAsync(CreateAtentimentoDTO atendimento);
    Task<AtendimentoDTO> UpdateAsync(Guid id, UpdateAtentimentoDTO atendimento);
    Task<bool> DeleteAsync(Guid id);
}