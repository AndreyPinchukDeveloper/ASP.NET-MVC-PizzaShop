using MediatR;
using ShopDomainLibrary;
using ShopApplication.Common.Exceptions;
using ShopApplication.Interfaces;

namespace ShopApplication.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderDbContext _dbContext;
        public DeleteOrderCommandHandler(IOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Order.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)//if not found
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            _dbContext.Order.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            //return Unit.Value;
        }
    }
}
