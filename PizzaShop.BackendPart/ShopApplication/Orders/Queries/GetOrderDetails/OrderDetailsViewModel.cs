using AutoMapper;
using ShopDomainLibrary;
using ShopApplication.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Orders.Queries.GetOrderDetails
{
    /// <summary>
    /// This class descriptions entities returning to user when user want to see (send request) order detail
    /// </summary>
    public class OrderDetailsViewModel:IMapWith<Order>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsViewModel>()
                .ForMember(orderVm => orderVm.Title,
                           opt => opt.MapFrom(order => order.Title))
                .ForMember(orderVm => orderVm.Details,
                           opt => opt.MapFrom(order => order.Details))
                .ForMember(orderVm => orderVm.Id,
                           opt => opt.MapFrom(order => order.Id))
                .ForMember(orderVm => orderVm.CreationDate,
                           opt => opt.MapFrom(order => order.CreationDate))
                .ForMember(orderVm => orderVm.EditDate,
                           opt => opt.MapFrom(order => order.EditDate));
        }
    }
}
