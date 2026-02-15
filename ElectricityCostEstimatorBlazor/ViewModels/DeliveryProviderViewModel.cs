using System.ComponentModel.DataAnnotations;

namespace ElectricityCostEstimatorBlazor.ViewModels
{
    public class DeliveryProviderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provider name is required")]
        public string ProviderName { get; set; }


        [Required(ErrorMessage = "Monthly charge is required")]
        [Range(0.00,100.00, ErrorMessage = "Monthly charge must be between 0 and 100")]
        public double MonthlyCharge { get; set; }


        [Required(ErrorMessage = "kWh Charge is required")]
        [Range(0.00000, 100.00000, ErrorMessage = "kWh charge must be between 0 and 100")]
        public double KWhCharge { get; set; }

        public string Description { get => $"{this.Id} - {this.ProviderName}"; }
    }
}
