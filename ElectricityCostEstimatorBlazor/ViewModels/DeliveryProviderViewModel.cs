using System.ComponentModel.DataAnnotations;

namespace ElectricityCostEstimatorBlazor.ViewModels
{
    public class DeliveryProviderViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ProviderName { get; set; }


        [Required]
        public double MonthlyCharge { get; set; }


        [Required]
        public double KWhCharge { get; set; }

        public string Description { get => $"{this.Id} - {this.ProviderName}"; }
    }
}
