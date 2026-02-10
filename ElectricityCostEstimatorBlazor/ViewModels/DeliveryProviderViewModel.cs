using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityCostEstimatorBlazor.ViewModels
{
    public class DeliveryProviderViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ProviderName { get; set; }
        public double MonthlyCharge { get; set; }
        public double KWhCharge { get; set; }
        public string Description { get => $"{this.Id} - {this.ProviderName}"; }
    }
}
