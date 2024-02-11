using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Data.Mapping
{
    public class PharmacyMapping : IEntityTypeConfiguration<Pharmacy>
    {
        public void Configure(EntityTypeBuilder<Pharmacy> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasMaxLength(Constants.KeyLength)
                 .IsRequired();


            builder.Property(x => x.UrlImage)
                 .HasMaxLength(500);

            builder.OwnsOne(x => x.Description).Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.OwnsOne(x => x.Description).Property(x => x.Description).HasMaxLength(500);

            builder.OwnsOne(x => x.Location).Property(x => x.Latitude);
            builder.OwnsOne(x => x.Location).Property(x => x.Longitude);
            builder.OwnsOne(x => x.Location).Property(x => x.Presicion);

            builder.OwnsMany(x => x.PharmacySchedules, b2 =>
            {
                b2.HasKey("Day","PharmacyId");
                b2.WithOwner("Pharmacy").HasForeignKey("PharmacyId");

            });
        }
    }
}
