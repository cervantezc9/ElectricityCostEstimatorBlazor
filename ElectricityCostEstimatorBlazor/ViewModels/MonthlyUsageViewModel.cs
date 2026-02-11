using ElectricityCostEstimatorBlazor.Data.Models;
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

        [Required]
        public int Usage { get; set; }
    }
}
