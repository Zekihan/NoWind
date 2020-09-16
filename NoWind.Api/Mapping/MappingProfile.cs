using AutoMapper;
using NoWind.Api.Resources;
using NoWind.Core.Models;

namespace NoWind.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Customers, CustomerResource>();

            // Resource to Domain
            CreateMap<CustomerResource, Customers>();

            // Domain to Resource
            CreateMap<Employees, EmployeesResource>();

            // Resource to Domain
            CreateMap<EmployeesResource, Employees>();
        }
    }
}
