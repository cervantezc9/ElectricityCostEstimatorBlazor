using ElectricityCostEstimatorBlazor.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityCostEstimatorBlazor.ViewModels
{
    public class MonthlyUsageViewModel
    {
        public int Id { get; set; }
        public Month Month { get; set; }
        public int Usage { get; set; }
        public EstimateViewModel Estimate { get; set; }
    }
}
