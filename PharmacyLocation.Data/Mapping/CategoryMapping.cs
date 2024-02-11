using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Data.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasMaxLength(Constants.KeyLength)
                 .IsRequired();


            builder.Property(x => x.UrlImage)
                 .HasMaxLength(500);

            builder.OwnsOne(x => x.Description).Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.OwnsOne(x => x.Description).Property(x => x.Description).HasMaxLength(500);        }
    }
}
