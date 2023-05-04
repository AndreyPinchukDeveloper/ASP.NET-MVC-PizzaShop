using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderListViewModel>
    {
        private readonly IOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderListViewModel> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orderQuery = await _dbContext.Order
                .Where(order => order.UserId == request.UserId)
                .ProjectTo<OrderLookupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderListViewModel { Orders = orderQuery };
        }
    }
}
