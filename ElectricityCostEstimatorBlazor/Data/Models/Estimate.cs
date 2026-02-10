using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityCostEstimatorBlazor.Data.Models
{
    public class Estimate : Timestamp
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int? ElectricityPlanId { get; set; }

        [ForeignKey("ElectricityPlanId")]
        public virtual ElectricityPlan ElectricityPlan { get; set; }

        public int? DeliveryId { get; set; }

        [ForeignKey("DeliveryId")]
        public virtual DeliveryProvider Delivery { get; set; }

        public virtual List<MonthlyUsage> MonthlyUsages { get; set; }
    }
}
