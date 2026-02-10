using ElectricityCostEstimatorBlazor.Data.Models;

namespace ElectricityCostEstimatorBlazor.ViewModels
{
    public class MonthlyUsageViewModel
    {
        List<MonthlyUsage> MonthlyUsages { get; set; } = [];
    }

    public class MonthlyUsage
    {
        public int Id { get; set; }
        public Month Month { get; set; }
        public int Usage { get; set; }
    }
}
