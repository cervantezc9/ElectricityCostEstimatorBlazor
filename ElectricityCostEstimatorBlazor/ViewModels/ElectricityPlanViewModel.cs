using System.ComponentModel.DataAnnotations;

namespace ElectricityCostEstimatorBlazor.ViewModels
{
    public class ElectricityPlanViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double BaseCharge { get; set; }

        public double Credit { get; set; }
        public int CreditMinimumUsage { get; set; }
        public List<ElectricityPlanRate> ElectricityPlanRates { get; set; }
        public string Description { get => $"{this.Id} - {this.Name}"; }

        public ElectricityPlanViewModel()
        {
            this.ElectricityPlanRates = new List<ElectricityPlanRate>();
        }
    }

    public class ElectricityPlanRate
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public int kWhMinimumUsage { get; set; }
        public int? kWhMaximumUsage { get; set; }
    }
}
