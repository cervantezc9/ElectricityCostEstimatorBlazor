using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityCostEstimatorBlazor.Data.Models
{
    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public class MonthlyUsage : Timestamp
    {
        [Key]
        public int Id { get; set; }
        public Month Month { get; set; }
        public int Usage { get; set; }
        public bool IsActive { get; set; }
        public int EstimateId { get; set; }

        [ForeignKey("EstimateId")]
        public virtual Estimate Estimate { get; set; }
    }
}
