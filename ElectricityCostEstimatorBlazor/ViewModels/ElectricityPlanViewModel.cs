using ElectricityCostEstimatorBlazor.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityCostEstimatorBlazor.ViewModels
{
    public class ElectricityPlanViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BaseCharge { get; set; }
        public double Credit { get; set; }
        public int CreditMinimumUsage { get; set; }
        public List<ElectricityPlanRateViewModel> ElectricityPlanRates { get; set; }
        public string Description { get => $"{this.Id} - {this.Name}"; }

        public ElectricityPlanViewModel()
        {
            this.ElectricityPlanRates = new List<ElectricityPlanRateViewModel>();
        }
    }
}
