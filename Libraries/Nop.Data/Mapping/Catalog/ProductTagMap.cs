using System.Data.Entity.ModelConfiguration;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    public partial class ProductTagMap : EntityTypeConfiguration<ProductTag>
    {
        public ProductTagMap()
        {
            this.ToTable("ProductTag");
            this.HasKey(pt => pt.Id);
            this.Property(pt => pt.Name).IsRequired().HasMaxLength(400);
        }
    }
}