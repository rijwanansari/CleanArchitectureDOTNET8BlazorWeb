using Application.Master.Dto;
using AutoMapper;
using Domain.Master;

namespace Application.Common.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AppSetting, AppSettingVm>().ReverseMap();
        //CreateMap<Purpose, PurposeVm>().ForMember(dest => dest.Require8105 , opt => opt.MapFrom(src => src.Requires8105)).ReverseMap();
    }
}
