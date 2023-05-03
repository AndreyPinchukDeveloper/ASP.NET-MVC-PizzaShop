using AutoMapper;
using ModelDomainLibrary;
using ShopApplication.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Orders.Queries.GetOrderList
{
    public class OrderLookupDTO:IMapWith<Order>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDTO>()
                .ForMember(orderDTO => orderDTO.Title,
                           opt => opt.MapFrom(order => order.Title))
                .ForMember(orderDTO => orderDTO.Id,
                           opt => opt.MapFrom(order => order.Id));
        }
    }
}
