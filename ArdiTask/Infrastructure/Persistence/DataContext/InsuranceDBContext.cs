using Application.Common.SoftDelete;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Persistence.DataContext
{
    public class InsuranceDBContext : DbContext
    {
        private readonly SoftDeleteInterceptor _softDeleteInterceptor;
        public InsuranceDBContext(DbContextOptions<InsuranceDBContext> options, SoftDeleteInterceptor softDeleteInterceptor) : base(options) 
        {
            _softDeleteInterceptor = softDeleteInterceptor;
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MedicalPolicy> MedicalPolicies { get; set; }
        public DbSet<TravelPolicy> TravelPolicies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
             
            options.AddInterceptors(_softDeleteInterceptor);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MedicalPolicy>()
                .HasOne(x => x.Customer).WithMany(x => x.MedicalPolicies).HasForeignKey(x => x.CustomerId);
            builder.Entity<MedicalPolicy>().HasQueryFilter(r => !r.IsDeleted);

            builder.Entity<TravelPolicy>()
                 .HasOne(x => x.Customer).WithMany(x => x.TravelPolicies).HasForeignKey(x => x.CustomerId);
            builder.Entity<TravelPolicy>().HasQueryFilter(r => !r.IsDeleted);

            builder.Entity<Customer>().HasQueryFilter(r => !r.IsDeleted); 
        }
      
  
    } 

}
