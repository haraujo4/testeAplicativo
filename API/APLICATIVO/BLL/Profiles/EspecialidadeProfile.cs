using AutoMapper;
using BLL.DTO;
using BLL.Models;

namespace BLL.Profiles;

public class EspecialidadeProfile:Profile
{
    public EspecialidadeProfile()
    {
        CreateMap<Especialidade, EspecialidadeDTO>().ReverseMap();
    }
}