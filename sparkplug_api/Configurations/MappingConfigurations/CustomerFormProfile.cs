using AutoMapper;
using SparkPlug.Models.Dtos;
using SparkPlug.Models.Dtos.Response;
using SparkPlug.Models.Entities;

namespace SparkPlug.Api.Configurations.MappingConfigurations
{
    public class CustomerFormProfile : Profile
    {
        public CustomerFormProfile()
        {
            CreateMap<CustomerForm, CreateCustomerFormDto>().ReverseMap();
            CreateMap<CustomerForm, UpdateCustomerFormDto>().ReverseMap();
            CreateMap<CustomerForm, CustomerFormResponseDto>().ReverseMap();
            
        }
    }
}
