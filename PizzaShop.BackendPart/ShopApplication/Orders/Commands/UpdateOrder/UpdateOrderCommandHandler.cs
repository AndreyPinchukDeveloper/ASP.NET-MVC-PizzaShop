
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelDomainLibrary;
using ShopApplication.Common.Exceptions;
using ShopApplication.Interfaces;

namespace ShopApplication.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler:IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderDbContext _dbContext;

        public UpdateOrderCommandHandler(IOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Order.FirstOrDefaultAsync(order =>
                order.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)//if not found
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            entity.Details = request.Deatils;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
