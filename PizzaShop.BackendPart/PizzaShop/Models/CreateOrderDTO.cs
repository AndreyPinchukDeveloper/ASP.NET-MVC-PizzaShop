namespace PizzaShop.Models
{
    public class CreateOrderDTO:IMapWith<CreateOrderCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDTO, CreateOrderCommand>()
                .ForMember(orderCommand => orderCommand.Title, 
                    opt => opt.MapFrom(orderDTO => orderDTO.Title))
                .ForMember(orderCommand => orderCommand.Details, 
                    opt => opt.MapFrom(orderDTO => orderDTO.Details));
        }
    }
}
