using Microsoft.EntityFrameworkCore;
using ModelDomainLibrary;
using ShopApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence
{
    public class PizzaDbContext : DbContext, IPizzaDbContext
    {
        public DbSet<PizzaModel> Pizza { get; set; }
        
    }
}
