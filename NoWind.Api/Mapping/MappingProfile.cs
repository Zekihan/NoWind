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

            // Domain to Resource
            CreateMap<Shippers, ShipperResource>();

            // Resource to Domain
            CreateMap<ShipperResource, Shippers>();

            // Domain to Resource
            CreateMap<Orders, OrderResource>();

            // Resource to Domain
            CreateMap<OrderResource, Orders>();
        }
    }
}
