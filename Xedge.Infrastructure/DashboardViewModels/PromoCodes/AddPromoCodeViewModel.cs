using System.ComponentModel.DataAnnotations;

namespace Xedge.Infrastructure.DashboardViewModels.PromoCodes
{
    public class AddPromoCodeViewModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public double DiscountPercent { get; set; }
    }
}
