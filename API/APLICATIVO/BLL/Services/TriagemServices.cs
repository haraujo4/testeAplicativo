using AutoMapper;
using BLL.DTO;
using BLL.Interface.Repository;
using BLL.Interface.Services;
using BLL.Models;

namespace BLL.Services;

public class TriagemServices:ITriagemServices
{
    private readonly IRepository<Triagem> _repository;
    private readonly IRepository<Atendimento> _atendimentoRepository;
    private readonly IMapper _mapper;
    
    public TriagemServices(IRepository<Triagem> repository,IRepository<Atendimento> atendimentoRepository,IMapper mapper)
    {
        _repository = repository;
        _atendimentoRepository = atendimentoRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TriagemDTO>> GetAllAsync()
    {
        var triagens = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TriagemDTO>>(triagens);
    }

    public async Task<TriagemDTO> GetByIdAsync(Guid id)
    {
        var triagem = await _repository.GetByIdAsync(id);
        return _mapper.Map<TriagemDTO>(triagem);
    }

    public async Task<TriagemDTO> CreateAsync(CreateTriagemDTO triagemDTO)
    {
        var verificaAtendimento = await _atendimentoRepository.GetByIdAsync(triagemDTO.AtendimentoId);
        if (verificaAtendimento == null)
            throw new Exception("Atendimento não encontrado");
        var triagem = _mapper.Map<Triagem>(triagemDTO);
        triagem.Id = Guid.NewGuid();
        await _repository.AddAsync(triagem);
        return _mapper.Map<TriagemDTO>(triagem);
    }

    public async Task<TriagemDTO> UpdateAsync(Guid id, UpdateTriagemDTO triagemDTO)
    {
        var triagem = await _repository.GetByIdAsync(id);
        if (triagem == null)
            return null;
        triagem = _mapper.Map(triagemDTO, triagem);
        await _repository.UpdateAsync(triagem);
        return _mapper.Map<TriagemDTO>(triagem);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var triagem = await _repository.GetByIdAsync(id);
        if (triagem == null)
            return false;
        await _repository.DeleteAsync(id);
        return true;
    }
}