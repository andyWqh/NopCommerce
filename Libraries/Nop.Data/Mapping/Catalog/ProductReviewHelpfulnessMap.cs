using System.Data.Entity.ModelConfiguration;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    public partial class ProductReviewHelpfulnessMap : EntityTypeConfiguration<ProductReviewHelpfulness>
    {
        public ProductReviewHelpfulnessMap()
        {
            this.ToTable("ProductReviewHelpfulness");
            this.HasKey(pr => pr.Id);

            this.HasRequired(prh => prh.ProductReview)
                .WithMany(pr => pr.ProductReviewHelpfulnessEntries)
                .HasForeignKey(prh => prh.ProductReviewId).WillCascadeOnDelete(true);
        }
    }
}