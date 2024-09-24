using AutoMapper;
using BLL.DTO;
using BLL.Models;

namespace BLL.Profiles;

public class TriagemProfile:Profile 
{
    public TriagemProfile()
    {
        CreateMap<Triagem, TriagemDTO>().ReverseMap();
        CreateMap<Triagem, CreateTriagemDTO>().ReverseMap();
        CreateMap<Triagem, UpdateTriagemDTO>().ReverseMap();
    }
    
}