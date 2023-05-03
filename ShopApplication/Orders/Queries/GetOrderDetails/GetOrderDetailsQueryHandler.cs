using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelDomainLibrary;
using ShopApplication.Common.Exceptions;
using ShopApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsViewModel>
    {
        private readonly IOrderDbContext _context;
        private IMapper _mapper;

        public GetOrderDetailsQueryHandler(IOrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDetailsViewModel> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.Order.FirstOrDefaultAsync(order =>
                order.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)//if not found
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            return _mapper.Map<OrderDetailsViewModel>(entity);
        }
    }
}
 