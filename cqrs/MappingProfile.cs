using AutoMapper;
using cqrs.CQRS.Commends;
using cqrs.Dto;
using cqrs.Entities;

namespace cqrs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ManagePersonCommand, Person>();
            CreateMap<Person, PersonDto>();
        }
    }
}
