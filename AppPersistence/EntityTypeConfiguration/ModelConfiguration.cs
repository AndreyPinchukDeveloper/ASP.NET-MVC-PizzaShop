using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelDomainLibrary;

namespace AppPersistence.EntityTypeConfiguration
{
    public class ModelConfiguration : IEntityTypeConfiguration<PizzaModel>
    {
        public void Configure(EntityTypeBuilder<PizzaModel> builder)
        {
            builder.HasKey(model => model.Id);
            builder.HasIndex(model => model.Id).IsUnique();
            builder.Property(model => model.Name).HasMaxLength(250);
        }
    }
}
