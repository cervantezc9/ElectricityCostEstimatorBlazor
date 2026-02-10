using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityCostEstimatorBlazor.Data.Models
{
    public class ElectricityPlanRate : Timestamp
    {
        [Key]
        public int Id { get; set; }
        public double Rate { get; set; }
        public int kWhMinimumUsage { get; set; }
        public int? kWhMaximumUsage { get; set; }
        public bool IsActive { get; set; }
        public int ElectricityPlanId { get; set; }

        [ForeignKey("ElectricityPlanId")]
        public virtual ElectricityPlan ElectricityPlan { get; set; }
    }
}
