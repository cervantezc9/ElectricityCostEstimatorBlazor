using ElectricityCostEstimatorBlazor.Data;
using ElectricityCostEstimatorBlazor.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectricityCostEstimatorBlazor.Services
{
    public class ElectricityEstimatorService
    {
        private IDbContextFactory<ElectricityDbContext> _dbContextFactory;
        private int electricityPlanRateId;

        public ElectricityEstimatorService(IDbContextFactory<ElectricityDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region Estimate

        public async Task AddEstimate(Estimate estimate)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Estimates.Add(estimate);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Estimate>> GetAllEstimates()
        {
            List<Estimate> estimates = [];

            using (var context = _dbContextFactory.CreateDbContext())
            {
                estimates = await context.Estimates.AsNoTracking()
                    .Include(est => est.ElectricityPlan)
                        .ThenInclude(plan => plan.ElectricityPlanRates)
                    .Include(est => est.Delivery)
                    .Include(est => est.MonthlyUsages)
                    .OrderBy(est => est.Id).ToListAsync();
            }

            return estimates;
        }

        public async Task<Estimate> GetEstimateById(int estimateId)
        {
            if (estimateId == 0)
            {
                return null;
            }

            Estimate estimate;

            using (var context = _dbContextFactory.CreateDbContext())
            {
                estimate = await context.Estimates.FirstOrDefaultAsync(est => est.Id == estimateId);
            }

            return estimate;
        }

        public async Task UpdateEstimate(Estimate estimate)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Estimates.Update(estimate);
                await context.SaveChangesAsync();
            }
        }

        #endregion

        #region DeliveryProvider

        public async Task<List<DeliveryProvider>> GetAllDeliverProviders()
        {
            List<DeliveryProvider> providers = [];

            using (var context = _dbContextFactory.CreateDbContext())
            {
                providers = await context.Deliveries.AsNoTracking().Where(delivery => delivery.IsActive).OrderBy(delivery => delivery.Id).ToListAsync();
            }

            return providers;
        }

        public async Task<DeliveryProvider> GetDeliveryProviderById(int deliveryProviderId)
        {
            if (deliveryProviderId == 0)
            {
                return null;
            }

            DeliveryProvider deliveryProvider;

            using (var context = _dbContextFactory.CreateDbContext())
            {
                deliveryProvider = await context.Deliveries.FirstOrDefaultAsync(delivery => delivery.Id == deliveryProviderId);
            }

            return deliveryProvider;
        }

        public async Task<int?> AddDeliveryProvider(DeliveryProvider provider)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Deliveries.Update(provider);
                await context.SaveChangesAsync();

                return provider.Id;
            }
        }

        #endregion

        #region Electricity Plan

        public async Task<List<ElectricityPlan>> GetAllElectricityPlans()
        {
            List<ElectricityPlan> plans = [];

            using (var context = _dbContextFactory.CreateDbContext())
            {
                plans = await context.ElectricityPlans
                    .Include(plan => plan.ElectricityPlanRates)
                    .Where(plan => plan.IsActive).ToListAsync();
            }

            return plans;
        }

        public async Task<ElectricityPlan> GetElectricityPlanById(int electricityPlanId)
        {
            if (electricityPlanId == 0)
            {
                return null;
            }

            ElectricityPlan electricityPlan;

            using(var context = _dbContextFactory.CreateDbContext())
            {
                electricityPlan = await context.ElectricityPlans
                    .Include(plan => plan.ElectricityPlanRates)
                    .FirstOrDefaultAsync(plan => plan.Id == electricityPlanId);
            }

            return electricityPlan;
        }
        public async Task<int?> AddElectricityPlan(ElectricityPlan plan)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.ElectricityPlans.Update(plan);
                await context.SaveChangesAsync();

                return plan.Id;
            }
        }


        #endregion

        #region Electricity Plan Rate

        public async Task<List<ElectricityPlanRate>> GetElectricityPlanRateByPlanId(int electricityPlanId)
        {
            if (electricityPlanRateId == 0)
            {
                return null;
            }

            List<ElectricityPlanRate> rates;

            using (var context = _dbContextFactory.CreateDbContext())
            {
                rates = await context.ElectricityPlanRates.Where(rate => rate.ElectricityPlanId == electricityPlanRateId).ToListAsync();
            }

            return rates;
        }

        #endregion

        #region MonthlyUsage

        public async Task<List<MonthlyUsage>> GetMonthlyUsageByEstimateId(int estimateId)
        {
            if (estimateId == 0)
            {
                return null;
            }

            List<MonthlyUsage> monthlyUsages;

            using (var context = _dbContextFactory.CreateDbContext())
            {
                monthlyUsages = await context.MonthlyUsages.Where(usage => usage.EstimateId == estimateId).ToListAsync();
            }

            return monthlyUsages;
        }

        #endregion
    }
}
