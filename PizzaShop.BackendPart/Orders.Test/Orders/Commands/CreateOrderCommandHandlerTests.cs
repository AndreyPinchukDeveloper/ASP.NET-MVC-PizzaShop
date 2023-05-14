using AppPersistence;
using Microsoft.EntityFrameworkCore;
using Orders.Test.Common;
using ShopApplication.Orders.Commands.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orders.Test.Orders.Commands
{
    public class CreateOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]//mark method to use it while test
        public async Task CreateOrderCommandHandler_Success()
        {
            //Arrange(first step) - prepare data for test
            var handler = new CreateOrderCommandHandler(_dbContext);//_dbContext from base class
            var orderName = "order name";
            var orderDetails = "order details";

            //Act(second step) - execute logic
            var orderId = await handler.Handle(
                new CreateOrderCommand
                {
                    Title = orderName,
                    Details = orderDetails,
                    UserId = OrdersContextFactory.UserAId
                },
                CancellationToken.None);

            //Assert(third step) - check the results
            Assert.NotNull(
                await _dbContext.Order.SingleOrDefaultAsync(order =>
                order.Id == orderId && order.Title == orderName &&
                order.Details == orderDetails));
        }
    }
}
