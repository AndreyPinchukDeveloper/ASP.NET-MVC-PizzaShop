using AutoMapper;
using ShopApplication.Common.Mapping;
using ShopApplication.Orders.Commands.UpdateOrder;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models
{
    public class UpdateOrderDTO:IMapWith<UpdateOrderCommand>
    {
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDTO, UpdateOrderCommand>()
                .ForMember(orderCommand => orderCommand.Id,
                    opt => opt.MapFrom(orderDTO => orderDTO.Id))
                .ForMember(orderCommand => orderCommand.Title,
                    opt => opt.MapFrom(orderDTO => orderDTO.Title))
                .ForMember(orderCommand => orderCommand.Deatils,
                    opt => opt.MapFrom(orderDTO => orderDTO.Details));
        }
    }
}
