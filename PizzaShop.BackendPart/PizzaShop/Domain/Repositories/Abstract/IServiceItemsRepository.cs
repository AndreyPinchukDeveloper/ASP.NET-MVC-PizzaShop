using PizzaShop.Domain.Entities;

namespace PizzaShop.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetTextServiceItemId(Guid id);
        void SaveServiceItem(ServiceItem item);
        void DeleteServiceItem(Guid id);
    }
}
