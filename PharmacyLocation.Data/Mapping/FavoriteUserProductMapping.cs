using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Data.Mapping
{
    public class FavoriteUserProductMapping : IEntityTypeConfiguration<FavoriteUserProduct>
    {
        public void Configure(EntityTypeBuilder<FavoriteUserProduct> builder)
        {
            builder.HasKey(x => new { x.IdProduct, x.IdUser});

            builder.Property(x => x.IdProduct)
                 .HasMaxLength(Constants.KeyLength)
                 .IsRequired();

            builder.Property(x => x.IdUser)
                .HasMaxLength(Constants.KeyUserId)
                .IsRequired();

            builder.HasOne("Product").WithMany().HasForeignKey("IdProduct").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
