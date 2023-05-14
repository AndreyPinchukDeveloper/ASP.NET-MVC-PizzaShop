using AppPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Test.Common
{
    /// <summary>
    /// This class tests commands whith dispose method for OrderDbContext
    /// </summary>
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly OrderDbContext _dbContext;

        public TestCommandBase()
        {
            _dbContext = OrdersContextFactory.Create();
        }

        public void Dispose()
        {
            OrdersContextFactory.Destroy(_dbContext);
        }
    }
}
