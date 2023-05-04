using PizzaShop.Domain.Repositories.Abstract;

namespace PizzaShop.Domain
{
    /// <summary>
    /// Entry point for data base context. This class manage our repositories
    /// </summary>
    public class DataManager
    {
        public ITextFieldRepository TextFields {  get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }
        public DataManager(ITextFieldRepository textFields, IServiceItemsRepository serviceItems)
        {
            TextFields = textFields;
            ServiceItems = serviceItems;
        }
    }
}
