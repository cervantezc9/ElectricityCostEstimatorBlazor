using ElectricityCostEstimatorBlazor.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityCostEstimatorBlazor.ViewModels
{
    public class ElectricityPlanRateViewModel
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public int kWhMinimumUsage { get; set; }
        public int? kWhMaximumUsage { get; set; }
        public virtual ElectricityPlanViewModel ElectricityPlan { get; set; }
    }
}
