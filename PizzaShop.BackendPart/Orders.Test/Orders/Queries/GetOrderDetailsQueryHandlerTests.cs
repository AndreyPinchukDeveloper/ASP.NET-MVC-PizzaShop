using AppPersistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orders.Test.Common;
using ShopApplication.Orders.Queries.GetOrderDetails;
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
    public class GetOrderDetailsQueryHandlerTests
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetOrderDetailsQueryHandler_Success()
        {
            //Arrange(first step) - prepare data for test
            var handler = new GetOrderDetailsQueryHandler(_context, _mapper);

            //Act(second step) - execute logic
            var result = await handler.Handle(
                new GetOrderDetailsQuery
                {
                    UserId = OrdersContextFactory.UserBId,
                    Id = Guid.Parse("064A8F43-2CC1-449A-AA60-738E62352242"),//get from OrdersContextFactory

                },
                CancellationToken.None);

            //Assert(third step) - check the results
            result.ShouldBeOfType<OrderDetailsViewModel>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
