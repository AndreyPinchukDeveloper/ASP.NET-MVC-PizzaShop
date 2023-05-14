using Microsoft.EntityFrameworkCore;
using Orders.Test.Common;
using ShopApplication.Common.Exceptions;
using ShopApplication.Orders.Commands.DeleteOrder;
using ShopApplication.Orders.Commands.UpdateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orders.Test.Orders.Commands
{
    public class UpdateOrderCommandHandlerTests:TestCommandBase
    {
        [Fact]
        public async Task UpdateOrderCommandHandler_Success()
        {
            //Arrange(first step) - prepare data for test
            var handler = new UpdateOrderCommandHandler(_dbContext);//_dbContext from base class
            var updatedTitle = "New Title";

            //Act(second step) - execute logic
            await handler.Handle(new UpdateOrderCommand
            {
                Id = OrdersContextFactory.OrderIdForUpdate,
                UserId = OrdersContextFactory.UserBId,
                Title = updatedTitle
            },
            CancellationToken.None);

            //Assert(third step) - check the results
            Assert.NotNull(await _dbContext.Order.SingleOrDefaultAsync(order =>
                order.Id == OrdersContextFactory.OrderIdForUpdate &&
                order.Title == updatedTitle));
        }

        [Fact]
        public async Task UpdateOrderCommandHandler_FailOnWrongId()
        {
            //Arrange(first step) - prepare data for test
            var handler = new UpdateOrderCommandHandler(_dbContext);//_dbContext from base class

            //Act(second step) - execute logic

            //Assert(third step) - check the results
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateOrderCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = OrdersContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateOrderCommandHandler_FailOnWrongUserId()
        {
            //Arrange(first step) - prepare data for test
            var handler = new UpdateOrderCommandHandler(_dbContext);//_dbContext from base class

            //Act(second step) - execute logic

            //Assert(third step) - check the results
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateOrderCommand
                    {
                        Id = OrdersContextFactory.OrderIdForUpdate,
                        UserId = OrdersContextFactory.UserAId
                    },
                    CancellationToken.None));
        }
    }
}
