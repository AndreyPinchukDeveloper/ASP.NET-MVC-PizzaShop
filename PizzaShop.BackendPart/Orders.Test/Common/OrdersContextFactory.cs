using AppPersistence;
using Microsoft.EntityFrameworkCore;
using ShopDomainLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                    Details = "Details2",
                    EditDate = null,
                    Id = Guid.Parse("601FE08D-900A-42F8-913D-8D501F2CB82F"),
                    Title = "Title2",
                    UserId = UserBId,
                },
                new Order
                {
                    CreationDate = DateTime.Today,
                    Details = "Details3",
                    EditDate = null,
                    Id = OrderIdForDelete,
                    Title = "Title3",
                    UserId = UserBId,
                },
                new Order
                {
                    CreationDate = DateTime.Today,
                    Details = "Details4",
                    EditDate = null,
                    Id = OrderIdForUpdate,
                    Title = "Title4",
                    UserId = UserBId,
                }
                );
            context.SaveChanges();
            return context;           
        }

        /// <summary>
        /// This method recieves context, ensure that database was deleted 
        /// and call Dispose for that context
        /// </summary>
        /// <param name="context"></param>
        public static void Destroy(OrderDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
