namespace PizzaShop.Identity.Data
{
    /// <summary>
    /// Initial our database
    /// </summary>
    public class DbInitializer
    {
        public static void Initialize(AuthorizationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
