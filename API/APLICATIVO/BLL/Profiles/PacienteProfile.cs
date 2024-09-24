using AutoMapper;
using BLL.DTO;
using BLL.Models;

namespace BLL.Profiles;

public class PacienteProfile:Profile
{
    public PacienteProfile()
    {
        CreateMap<Paciente, PacienteDTO>();

        CreateMap<PacienteDTO, Paciente>();

        CreateMap<CreatePacienteDTO, Paciente>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); 

        CreateMap<UpdatePacienteDTO, Paciente>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); 


    }
}