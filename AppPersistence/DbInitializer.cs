using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence
{
    /// <summary>
    /// Sheck for existing db here and create it if necessary
    /// </summary>
    public class DbInitializer
    {
        public static void Initialize(OrderDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
