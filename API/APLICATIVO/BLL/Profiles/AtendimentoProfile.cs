using AutoMapper;
using BLL.DTO;
using BLL.Models;

namespace BLL.Profiles;

public class AtendimentoProfile:Profile
{
    public AtendimentoProfile()
    {
        CreateMap<Atendimento, AtendimentoDTO>();
        CreateMap<CreateAtentimentoDTO, Atendimento>();
        CreateMap<UpdateAtentimentoDTO, Atendimento>();
    }
    
}