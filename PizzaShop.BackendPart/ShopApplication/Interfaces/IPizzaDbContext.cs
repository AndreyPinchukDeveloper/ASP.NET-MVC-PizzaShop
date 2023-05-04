using Microsoft.EntityFrameworkCore;
using ModelDomainLibrary;

namespace ShopApplication.Interfaces
{
    /// <summary>
    /// Save context changes to the data base
    /// </summary>
    public interface IPizzaDbContext
    {
        DbSet<PizzaModel> Pizza { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
