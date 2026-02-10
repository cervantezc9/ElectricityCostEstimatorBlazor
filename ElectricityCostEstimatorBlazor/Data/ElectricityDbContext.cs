using Microsoft.EntityFrameworkCore;

namespace ElectricityCostEstimatorBlazor.Data
{
    public class ElectricityDbContext : DbContext
    {
        public DbSet<Models.DeliveryProvider> Deliveries { get; set; }
        public DbSet<Models.ElectricityPlanRate> ElectricityPlanRates { get; set; }
        public DbSet<Models.ElectricityPlan> ElectricityPlans { get; set; }
        public DbSet<Models.MonthlyUsage> MonthlyUsages { get; set; }
        public DbSet<Models.Estimate> Estimates { get; set; }

        public ElectricityDbContext(DbContextOptions<ElectricityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Estimate>()
                .HasOne(estimate => estimate.Delivery)
                .WithMany()
                .HasForeignKey(estimate => estimate.DeliveryId);

            modelBuilder.Entity<Models.Estimate>()
                .HasOne(estimate => estimate.ElectricityPlan)
                .WithMany()
                .HasForeignKey(estimate => estimate.ElectricityPlanId);

            modelBuilder.Entity<Models.ElectricityPlanRate>()
                .HasOne(rate => rate.ElectricityPlan)
                .WithMany(plan => plan.ElectricityPlanRates)
                .HasForeignKey(rate => rate.ElectricityPlanId);

            modelBuilder.Entity<Models.MonthlyUsage>()
                .HasOne(usage => usage.Estimate)
                .WithMany(estimate => estimate.MonthlyUsages)
                .HasForeignKey(usage => usage.EstimateId);
        }
    }
}
