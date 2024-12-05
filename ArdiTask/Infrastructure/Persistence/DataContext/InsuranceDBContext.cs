using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DataContext
{
    public class InsuranceDBContext : DbContext
    {
        public InsuranceDBContext(DbContextOptions<InsuranceDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MedicalPolicy>()
                .HasOne(x => x.Customer).WithMany(x => x.MedicalPolicies).HasForeignKey(x => x.CustomerId);

            builder.Entity<TravelPolicy>()
                 .HasOne(x => x.Customer).WithMany(x => x.TravelPolicies).HasForeignKey(x => x.CustomerId);
                 
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MedicalPolicy> MedicalPolicies { get; set; }
        public DbSet<TravelPolicy> TravelPolicies { get; set; }
    }
}
