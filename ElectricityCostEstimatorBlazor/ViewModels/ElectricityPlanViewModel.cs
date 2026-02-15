using System.ComponentModel.DataAnnotations;

namespace ElectricityCostEstimatorBlazor.ViewModels
{
    public class ElectricityPlanViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Plan name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Base charge is required")]
        [Range(0.00, 100.00, ErrorMessage = "Base charge must be between 0 and 100")]
        public double BaseCharge { get; set; }

        [Range(0.00, 100.00, ErrorMessage = "Credit must be between 0 and 100")]
        public double Credit { get; set; }

        [Range(0, 10000, ErrorMessage = "Credit minimum usage must be between 0 and 10,000")]
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

        [Range(0.00, 100.00, ErrorMessage = "Rate must be between 0 and 100")]
        public double Rate { get; set; }

        public int kWhMinimumUsage { get; set; }
        public int? kWhMaximumUsage { get; set; }
    }
}
