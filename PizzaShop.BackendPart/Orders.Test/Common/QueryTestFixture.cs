using AppPersistence;
using AutoMapper;
using ShopApplication.Common.Mapping;
using ShopApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orders.Test.Common
{
    public class QueryTestFixture : IDisposable
    {
        public OrderDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = OrdersContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssymblyMappingProfile(
                    typeof(IOrderDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            OrdersContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
