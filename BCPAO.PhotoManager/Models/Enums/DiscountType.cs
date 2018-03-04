using System.ComponentModel.DataAnnotations;

namespace BCPAO.PhotoManager.Models.Enums
{
    public enum DiscountType
    {
        [Display(Name = "None")]
        None,

        [Display(Name = "Percentage")]
        Percentage,

        [Display(Name = "Flat Amount")]
        FlatAmount
    }
}
