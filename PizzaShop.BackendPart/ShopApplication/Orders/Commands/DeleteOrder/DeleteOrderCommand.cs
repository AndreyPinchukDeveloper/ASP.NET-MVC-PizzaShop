using MediatR;

namespace ShopApplication.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand: IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
