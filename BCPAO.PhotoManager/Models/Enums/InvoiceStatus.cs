using System.ComponentModel.DataAnnotations;

namespace BCPAO.PhotoManager.Models.Enums
{
    public enum InvoiceStatus
    {
        [Display(Name = "Pending Payment")]
        Pending,

        [Display(Name = "Paid")]
        Paid
    }
}
