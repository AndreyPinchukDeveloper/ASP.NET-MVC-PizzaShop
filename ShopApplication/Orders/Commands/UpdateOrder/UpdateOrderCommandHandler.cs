using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelDomainLibrary;
using ShopApplication.Interfaces;
using ShopApplication.Orders.Commands.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler:IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderDbContext _dbContext;

        public UpdateOrderCommandHandler(IOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Order.FirstOrDefaultAsync(order =>
                order.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {

            }

            return Unit.Value;
        }
    }
}
