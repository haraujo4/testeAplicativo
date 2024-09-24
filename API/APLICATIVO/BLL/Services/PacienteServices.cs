using AutoMapper;
using BLL.DTO;
using BLL.Interface.Repository;
using BLL.Interface.Services;
using BLL.Models;
using Hangfire;

namespace BLL.Services;

public class PacienteServices:IPacienteServices
{
    private readonly IRepository<Paciente> _repository;
    private readonly IMapper _mapper;
    private readonly IRepository<Atendimento> _atendimentoRepository;
    
    public PacienteServices(IRepository<Paciente> repository, IRepository<Atendimento> atendimentoRepository, IMapper mapper)
    {
        _repository = repository;
        _atendimentoRepository = atendimentoRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<PacienteDTO>> GetAllPacientesAsync()
    {
        var pacientes = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PacienteDTO>>(pacientes);
    }

    public async Task<PacienteDTO> GetPacienteByIdAsync(Guid id)
    {
        var paciente = _mapper.Map<PacienteDTO>(await _repository.GetByIdAsync(id));
        return paciente;
    }

    public async Task<PacienteDTO> GetByEmailAsync(string email)
    {
        var paciente = _mapper.Map<PacienteDTO>(await _repository.GetByConditionAsync(x => x.Email == email));
        return paciente;
    }

    public async Task<PacienteDTO> AddPacienteAsync(CreatePacienteDTO paciente)
    { 
        var pacienteExist = await _repository.GetByConditionAsync(x => x.Email == paciente.Email);
        if(pacienteExist != null)
        {
            throw new Exception("Paciente já cadastrado");
        }
        var newPaciente = _mapper.Map<Paciente>(paciente);
        var result = await _repository.AddAsync(newPaciente);

        var atendimento = new Atendimento(result.Id, DateTime.Now, true);

        BackgroundJob.Enqueue(() => _atendimentoRepository.AddAsync(atendimento));

        return _mapper.Map<PacienteDTO>(result);

    }

    public async Task<PacienteDTO> UpdatePacienteAsync(Guid id, UpdatePacienteDTO paciente)
    {
        var pacienteToUpdate = await _repository.GetByIdAsync(id);
        if(pacienteToUpdate == null)
        {
            throw new Exception("Paciente não encontrado");
        }
        pacienteToUpdate.Nome = paciente.Nome;
        pacienteToUpdate.Email = paciente.Email;
        pacienteToUpdate.Telefone = paciente.Telefone;
        await _repository.UpdateAsync(pacienteToUpdate);
        
        var atendimento = new Atendimento(pacienteToUpdate.Id, DateTime.Now, true);

        BackgroundJob.Enqueue(() => _atendimentoRepository.AddAsync(atendimento));
        
        return _mapper.Map<PacienteDTO>(pacienteToUpdate);
    }

    public async Task<bool> DeletePacienteAsync(Guid id)
    {
        var pacienteToDelete = await _repository.GetByIdAsync(id);
        var result = await _repository.DeleteAsync(pacienteToDelete.Id);
        return result;
        
        
    }
}