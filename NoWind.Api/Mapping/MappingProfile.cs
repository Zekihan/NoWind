using AutoMapper;
using NoWind.Api.APIModels;
using NoWind.Core.Models;

namespace NoWind.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer Domain to Resource
            CreateMap<Customers, CustomerAPIModel>();

            // Customer Resource to Domain
            CreateMap<CustomerAPIModel, Customers>();

            // Employee Domain to Resource
            CreateMap<Employees, EmployeeAPIModel>();

            // Employee Resource to Domain
            CreateMap<EmployeeAPIModel, Employees>();

            // Shipper Domain to Resource
            CreateMap<Shippers, ShipperAPIModel>();

            // Shipper Resource to Domain
            CreateMap<ShipperAPIModel, Shippers>();

            // Order Domain to Resource
            CreateMap<Orders, OrderAPIModel>();

            // Order Resource to Domain
            CreateMap<OrderAPIModel, Orders>();
        }
    }
}
