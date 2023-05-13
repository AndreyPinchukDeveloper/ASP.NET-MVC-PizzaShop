using AppPersistence;
using Microsoft.EntityFrameworkCore;
using ShopDomainLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Test.Common
{
    public class OrdersContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid OrderIdForDelete = Guid.NewGuid();
        public static Guid OrderIdForUpdate = Guid.NewGuid();

        public static OrderDbContext Create()
        {
            var options = new DbContextOptionsBuilder<OrderDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new OrderDbContext(options);
            context.Database.EnsureCreated();//to be sure it was created
            context.Order.AddRange(
                new Order
                {
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    EditDate = null,
                    Id = Guid.Parse("064A8F43-2CC1-449A-AA60-738E62352242"),
                    Title = "Title1",
                    UserId = UserAId,
                },
                new Order
                {
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    EditDate = null,
                    Id = Guid.Parse("064A8F43-2CC1-449A-AA60-738E62352242"),
                    Title = "Title1",
                    UserId = UserAId,
                }
                );

        }
    }
}
