using ElectricityCostEstimatorBlazor.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityCostEstimatorBlazor.ViewModels
{
    public class EstimateViewModel
    {
        public int Id { get; set; }
        public ElectricityPlanViewModel ElectricityPlan { get; set; }
        public DeliveryProviderViewModel Delivery { get; set; }
        public List<MonthlyUsageViewModel> MonthlyUsages { get; set; }
        public double AnnualTotal { get; set; }
        public string Description
        {
            get => $"{this.Id} - {this.ElectricityPlan?.Name} ({this.Delivery?.ProviderName})";
        }

        public EstimateViewModel()
        {
            this.MonthlyUsages = new List<MonthlyUsageViewModel>();
        }

        public double GetChargeTotal(Month month)
        {
            return GetDeliveryCharge(month) + GetUsageCharge(month) - GetCredit(month);
        }

        public double GetAnnualTotal()
        {
            AnnualTotal = 0;
            foreach (var monthlyUsage in MonthlyUsages)
            {
                AnnualTotal += GetChargeTotal(monthlyUsage.Month);
            }
            return AnnualTotal;
        }

        public double GetDeliveryCharge(Month month)
        {
            double delvieryCharge = Delivery?.MonthlyCharge ?? 0;
            MonthlyUsageViewModel monthlyUsage = MonthlyUsages.FirstOrDefault(x => x.Month == month);

            delvieryCharge += ((Delivery?.KWhCharge ?? 0) / 100) * (monthlyUsage?.Usage ?? 0);

            return delvieryCharge;
        }

        public double GetCredit(Month month)
        {
            double credit = 0;
            MonthlyUsageViewModel monthlyUsage = MonthlyUsages.FirstOrDefault(x => x.Month == month);

            if ((monthlyUsage?.Usage ?? 0) >= (ElectricityPlan?.CreditMinimumUsage ?? 0))
            {
                credit = ElectricityPlan?.Credit ?? 0;
            }

            return credit;
        }

        public double GetUsageCharge(Month month)
        {
            MonthlyUsageViewModel monthlyUsage = MonthlyUsages.FirstOrDefault(x => x.Month == month);
            double charge = ElectricityPlan?.BaseCharge ?? 0;

            if (monthlyUsage != null)
            {
                int runningUsage = monthlyUsage.Usage;

                foreach (ElectricityPlanRateViewModel rate in ElectricityPlan.ElectricityPlanRates
                    .Where(x => x.Rate > 0).OrderBy(x => (x.kWhMaximumUsage ?? int.MaxValue)).ToList())
                {
                    int tierUsage = (runningUsage >= ((rate.kWhMaximumUsage ?? int.MaxValue) - rate.kWhMinimumUsage)
                        ? ((rate.kWhMaximumUsage ?? int.MaxValue) - rate.kWhMinimumUsage) : runningUsage);

                    charge += GetRateTierChage(rate, tierUsage);
                    runningUsage -= tierUsage;
                }
            }
            return charge;
        }

        private double GetRateTierChage(ElectricityPlanRateViewModel rate, int usage)
        {
            double charge = 0;

            if (usage > 0)
            {
                charge += (rate.Rate / 100) * usage;
            }

            return charge;
        }
    }
}
