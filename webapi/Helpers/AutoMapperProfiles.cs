using AutoMapper;
using webapi.DTO;
using webapi.Models;

namespace webapi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<Contract, ContractDTO>();
        }
    }
}