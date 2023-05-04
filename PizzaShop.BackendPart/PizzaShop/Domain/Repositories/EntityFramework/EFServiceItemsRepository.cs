using Microsoft.EntityFrameworkCore;
using PizzaShop.Data.Services;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Repositories.Abstract;

namespace PizzaShop.Domain.Repositories.EntityFramework
{
    /// <summary>
    /// Implementation especially for EFCore based on IServiceItemsRepository
    /// </summary>
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext _context;
        public EFServiceItemsRepository(AppDbContext context)
        {
            _context = context;
        }
        public void DeleteServiceItem(Guid id)
        {
            _context.ServiceItem.Remove(new ServiceItem() { Id = id });
            _context.SaveChanges();
        }

        public IQueryable<ServiceItem> GetServiceItems()
        {
            return _context.ServiceItem;
        }

        public ServiceItem GetTextServiceItemId(Guid id)
        {
            return _context.ServiceItem.FirstOrDefault(x => x.Id == id);
        }

        public void SaveServiceItem(ServiceItem item)
        {
            if (item.Id == default) _context.Entry(item).State = EntityState.Added;
            else _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
