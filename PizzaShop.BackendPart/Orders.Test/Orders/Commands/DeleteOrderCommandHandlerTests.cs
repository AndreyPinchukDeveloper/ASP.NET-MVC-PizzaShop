using Microsoft.EntityFrameworkCore;
using Orders.Test.Common;
using ShopApplication.Common.Exceptions;
using ShopApplication.Orders.Commands.CreateOrder;
using ShopApplication.Orders.Commands.DeleteOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orders.Test.Orders.Commands
{
    public class DeleteOrderCommandHandlerTests:TestCommandBase
    {
        [Fact]//mark method to use it while test
        public async Task DeleteOrderCommandHandler_Success()
        {
            //Arrange(first step) - prepare data for test
            var handler = new DeleteOrderCommandHandler(_dbContext);//_dbContext from base class

            //Act(second step) - execute logic
            await handler.Handle(new DeleteOrderCommand
            {
                Id = OrdersContextFactory.OrderIdForDelete,
                UserId = OrdersContextFactory.UserAId
            }, 
            CancellationToken.None);

            //Assert(third step) - check the results
            Assert.Null(_dbContext.Order.SingleOrDefault(order=>
                order.Id == OrdersContextFactory.OrderIdForDelete));
        }

        public async Task DeleteOrderCommandHandler_FailOnWrongId()
        {
            //Arrange(first step) - prepare data for test
            var handler = new DeleteOrderCommandHandler(_dbContext);//_dbContext from base class

            //Act(second step) - execute logic


            //Assert(third step) - check the results
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteOrderCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = OrdersContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteOrderCommandHandler_FailOnWrongUserId()
        {
            //Arrange(first step) - prepare data for test
            var deleteHandler = new DeleteOrderCommandHandler(_dbContext);//_dbContext from base class
            var createHandler = new CreateOrderCommandHandler(_dbContext);
            var noteId = await createHandler.Handle(
                new CreateOrderCommand
                {
                    Title = "OrderTitle",
                    UserId = OrdersContextFactory.UserAId
                },
                CancellationToken.None);

            //Act(second step) - execute logic

            //Assert(third step) - check the results
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteOrderCommand
                    {
                        Id = noteId,
                        UserId = OrdersContextFactory.UserBId
                    },
                    CancellationToken.None));
        }
    }
}
