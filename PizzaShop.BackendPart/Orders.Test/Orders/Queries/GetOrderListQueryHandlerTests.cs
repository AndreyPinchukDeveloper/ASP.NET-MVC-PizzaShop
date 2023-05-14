using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orders.Test.Orders.Queries
{
    public class GetOrderListQueryHandlerTests
    {
        [Fact]
        public void GetOrderListQueryHandler_Success()
        {
            var handler = new GetOrderListQueryHandler();
        }

    }
}
