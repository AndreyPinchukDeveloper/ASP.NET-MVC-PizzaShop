using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDomainLibrary;

namespace AppPersistence.EntityTypeConfiguration
{
    /// <summary>
    /// This class implements IEntityTypeConfiguration<T>
    /// by using that interface we can separated entity's configurations (Order as example)
    /// if we don't do that we must do it in method OnModelCreating(OrderDbContext)
    /// </summary>
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// This method contains parameters for configuration
        /// id - is our key
        /// HasIndex.IsUnique - it's uniq
        /// Property.HasMaxLength - title can't be more than 250 symbols
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.HasIndex(order => order.Id).IsUnique();
            builder.Property(order => order.Title).HasMaxLength(250);
        }
    }
}
