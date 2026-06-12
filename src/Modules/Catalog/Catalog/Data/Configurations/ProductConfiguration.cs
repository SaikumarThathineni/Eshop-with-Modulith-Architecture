namespace Catalog.Data.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Category).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(200);
        builder.Property(c => c.ImageFile).HasMaxLength(100);
        builder.Property(c => c.Price).IsRequired();
    }
}
