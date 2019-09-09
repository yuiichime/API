using AutoMapper;
using Domain.Entities;
using Infrastructure.CrossCutting.Models;

namespace Infrastructure.CrossCutting.Helpers
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<User, UserEntity>();
            CreateMap<Address,AddressEntity>();
            CreateMap<Phones, PhonesEntity>();
        }
    }

    public class MappingDTO : Profile
    {
        public MappingDTO()
        {
            CreateMap<UserEntity,User>();
            CreateMap<AddressEntity, Address>();
            CreateMap<Phones,Phones>();

        }
    }
}
