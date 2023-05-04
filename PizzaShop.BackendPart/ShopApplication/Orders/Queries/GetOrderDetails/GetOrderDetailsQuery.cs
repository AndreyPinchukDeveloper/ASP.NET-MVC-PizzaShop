using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery:IRequest<OrderDetailsViewModel>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
