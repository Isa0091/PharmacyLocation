using Isa0091.Domain.Context;
using Isa0091.Domain.Core.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Data
{
    public class PharmacyLocationContext : BaseContext<PharmacyLocationContext>
    {
        public PharmacyLocationContext(DbContextOptions<PharmacyLocationContext> options, IMediator mediator, IIntegrationEventSender sender, ILogger<PharmacyLocationContext> logger) : base(options, mediator, sender, logger)
        {

        }

        public DbSet<FavoriteUserProduct> FavoriteUserProducts { get; set; }

        public DbSet<Pharmacy> Pharmacies { get; set; }

        public DbSet<PharmacyProduct> PharmacyProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            b.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
