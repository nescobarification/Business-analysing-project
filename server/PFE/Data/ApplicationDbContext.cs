using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PFE.Models;

namespace MVC5App.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Feature> Feature { get; set; }
        public DbSet<MetricFeature> MetricFeature { get; set; }
        public DbSet<SummaryFeature> SummaryFeature { get; set; }
        public DbSet<PdfAcquisition> PdfAcquisition { get; set; }
        public DbSet<SummaryAcquisition> SummaryAcquisitions { get; set; }
        public DbSet<ApplicationUser> ApplicationUser {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
