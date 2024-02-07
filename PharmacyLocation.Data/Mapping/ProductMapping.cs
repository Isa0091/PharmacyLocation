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
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasMaxLength(Constants.KeyLength)
                 .IsRequired();

            builder.Property(x => x.UrlImage)
                .HasMaxLength(500);

            builder.OwnsOne(x => x.Description).Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.OwnsOne(x => x.Description).Property(x => x.Description).HasMaxLength(500);

        }
    }
}
