using Microsoft.EntityFrameworkCore;
using ModelDomainLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Order> Order { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
