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
    public class PharmacyProductMapping : IEntityTypeConfiguration<PharmacyProduct>
    {
        public void Configure(EntityTypeBuilder<PharmacyProduct> builder)
        {
            builder.HasKey(x => new { x.IdProduct, x.IdPharmacy });

            builder.Property(x => x.IdProduct)
                 .HasMaxLength(Constants.KeyLength)
                 .IsRequired();

            builder.Property(x => x.IdPharmacy)
                .HasMaxLength(Constants.KeyLength)
                .IsRequired();

            builder.HasOne("Product").WithMany().HasForeignKey("IdProduct").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne("Pharmacy").WithMany().HasForeignKey("IdPharmacy").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
