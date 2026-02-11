using System.ComponentModel.DataAnnotations;

namespace ElectricityCostEstimatorBlazor.Data.Models
{
    public class ElectricityPlan : Timestamp
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double BaseCharge { get; set; }
        public double Credit { get; set; }
        public int CreditMinimumUsage { get; set; }
        public bool IsActive { get; set; }
        public virtual List<ElectricityPlanRate> ElectricityPlanRates { get; set; }
    }
}
