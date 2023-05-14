using AppPersistence;
using AutoMapper;
using Orders.Test.Common;
using ShopApplication.Orders.Commands.DeleteOrder;
using ShopApplication.Orders.Queries.GetOrderList;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orders.Test.Orders.Queries
{
    [Collection("QueryCollection")]
    public class GetOrderListQueryHandlerTests
    {
        private readonly OrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandlerTests(QueryTestFixture fixture)
        {
            _dbContext = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetOrderListQueryHandler_Success()
        {
            //Arrange(first step) - prepare data for test
            var handler = new GetOrderListQueryHandler(_dbContext, _mapper);

            //Act(second step) - execute logic
            var result = await handler.Handle(
                new GetOrderListQuery
                {
                    UserId = OrdersContextFactory.UserBId
                },
                CancellationToken.None);

            //Assert(third step) - check the results
            result.ShouldBeOfType<OrderListViewModel>();
            result.Orders.Count.ShouldBe(2);
        }

    }
}
