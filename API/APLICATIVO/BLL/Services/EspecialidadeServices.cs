using AutoMapper;
using BLL.DTO;
using BLL.Interface.Repository;
using BLL.Interface.Services;
using BLL.Models;

namespace BLL.Services;

public class EspecialidadeServices:IEspecialidadeServices
{
    private readonly IRepository<Especialidade> _repository;
    private readonly IMapper _mapper;
    
    public EspecialidadeServices(IRepository<Especialidade> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<EspecialidadeDTO>> GetAllAsync()
    {
        var especialidades = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<EspecialidadeDTO>>(especialidades);
    }

    public async Task<EspecialidadeDTO> GetByIdAsync(Guid id)
    {
        var especialidade = await _repository.GetByIdAsync(id);
        return _mapper.Map<EspecialidadeDTO>(especialidade);
    }

    public async Task<EspecialidadeDTO> GeyByEspecialidadeAsync(string especialidade)
    {
        var especialidades = await _repository.GetAllAsync();
        var especialidadeDTO = especialidades.FirstOrDefault(x => x.TipoEspecialidade == especialidade.ToUpper());
        return _mapper.Map<EspecialidadeDTO>(especialidadeDTO);
    }
}