using System.ComponentModel.DataAnnotations;

namespace ElectricityCostEstimatorBlazor.ViewModels
{
    public class MonthlyUsageViewModel
    {
        public List<MonthlyUsage> MonthlyUsages { get; set; } = [];
    }

    public class MonthlyUsage
    {
        public int Id { get; set; }
        public int Month { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(0, 5000, ErrorMessage = "Usage must be between 0 and  5,000")]
        public int Usage { get; set; }
    }
}
