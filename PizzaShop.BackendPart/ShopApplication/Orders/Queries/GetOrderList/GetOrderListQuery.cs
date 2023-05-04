using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery:IRequest<OrderListViewModel>
    {
        public Guid UserId { get; set; }
    }
}
