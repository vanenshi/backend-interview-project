using Application.Customer.Dtos;
using AutoMapper;

namespace Application.Common
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Customer, CustomerRequestDto>().ReverseMap();

            CreateMap<Domain.Customer, CustomerResultDto>().ReverseMap();
        }
    }
}
