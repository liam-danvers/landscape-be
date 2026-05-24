using AutoMapper;
using landscape_be.models;
using landscape_be.models.dto;

namespace landscape_be.mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // maps both directions
            CreateMap<Employee, EmployeeDto>().ReverseMap()
                // if you always want to ignore Id when mapping from DTO to entity (e.g. create)
                .ForMember(dest => dest.Id, opt => opt.Condition((src, dest, srcMember) => srcMember != 0));
        }
    }
}
