using AutoMapper;
using BiddingService.DTOs;
using BiddingService.Models;

namespace BiddingService.RequestComponents;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Bidding, BiddingDto>().IncludeMembers(x => x.Aircraft);
        CreateMap<Aircraft, BiddingDto>();
        CreateMap<CreateBiddingDto, Bidding>()
            .ForMember(b => b.Aircraft, k => k.MapFrom(p => p));
        CreateMap<CreateBiddingDto, Aircraft>();
    }
}
