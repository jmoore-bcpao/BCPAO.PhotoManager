using System.ComponentModel.DataAnnotations;

namespace BCPAO.PhotoManager.Models.Enums
{
    public enum PackageLogStatus
    {
        [Display(Name="Dispatched To Courier")]
        Dispatched,

        [Display(Name = "Received By Courier")]
        Received,

        [Display(Name = "Delivered To Consignee")]
        Delivered
    }
}
