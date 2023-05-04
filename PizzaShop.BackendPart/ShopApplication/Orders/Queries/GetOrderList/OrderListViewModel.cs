using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Orders.Queries.GetOrderList
{
    /// <summary>
    /// Contains list of orders
    /// </summary>
    public class OrderListViewModel
    {
        public IList<OrderLookupDTO> Orders { get; set; }
    }
}
