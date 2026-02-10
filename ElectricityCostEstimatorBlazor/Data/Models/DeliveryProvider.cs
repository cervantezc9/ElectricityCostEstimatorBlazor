using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityCostEstimatorBlazor.Data.Models
{
    public class DeliveryProvider : Timestamp
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProviderName { get; set; }

        public double MonthlyCharge { get; set; }
        public double KWhCharge { get; set; }
        public bool IsActive { get; set; }
    }
}
