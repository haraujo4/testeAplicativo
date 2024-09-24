using AutoMapper;
using BLL.DTO;
using BLL.Interface.Repository;
using BLL.Interface.Services;
using BLL.Models;

namespace BLL.Services;

public class AtendimentoServices: IAtendimentoServices
{
    private readonly IRepository<Atendimento> _repository;
    private readonly IRepository<Paciente> _pacienteRepository;
    private readonly IMapper _mapper;
    
    public AtendimentoServices(IRepository<Atendimento> repository, IMapper mapper, IRepository<Paciente> pacienteRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _pacienteRepository = pacienteRepository;
    }
    public async Task<IEnumerable<AtendimentoDTO>> GetAllAsync()
    {
        var atendimentos = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<AtendimentoDTO>>(atendimentos);
    }

    public async Task<AtendimentoDTO> GetByIdAsync(Guid id)
    {
        var atendimento = await _repository.GetByIdAsync(id);
        return _mapper.Map<AtendimentoDTO>(atendimento);
    }

    public async Task<AtendimentoDTO> AddAsync(CreateAtentimentoDTO atendimento)
    {
        var verificaPaciente = await _pacienteRepository.GetByIdAsync(atendimento.PacienteId);
        if(verificaPaciente == null)
            throw new Exception("Paciente não encontrado");
        var atendimentoModel = _mapper.Map<Atendimento>(atendimento);
        var atendimentoAdded = await _repository.AddAsync(atendimentoModel);
        return _mapper.Map<AtendimentoDTO>(atendimentoAdded);
    }

    public async Task<AtendimentoDTO> UpdateAsync(Guid id, UpdateAtentimentoDTO atendimento)
    {
        var verificaPaciente = await _repository.GetByIdAsync(atendimento.PacienteId);
        if (verificaPaciente == null)
        {
            throw new Exception("Paciente não encontrado");
        }
        var atendimentoModel = _mapper.Map<Atendimento>(atendimento);
        var atendimentoUpdated = await _repository.UpdateAsync(atendimentoModel);
        return _mapper.Map<AtendimentoDTO>(atendimentoUpdated);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var verificaAtendimento = await _repository.GetByIdAsync(id);
        if (verificaAtendimento == null)
        {
            throw new Exception("Atendimento não encontrado");
        }

        return await _repository.DeleteAsync(id);
    }
}