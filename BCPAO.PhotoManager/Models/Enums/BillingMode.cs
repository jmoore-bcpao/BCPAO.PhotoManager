using System.ComponentModel.DataAnnotations;

namespace BCPAO.PhotoManager.Models.Enums
{
    public enum BillingMode
    {
        [Display(Name = "Pay Now")]
        PayNow,

        [Display(Name = "Cash On Delivery")]
        CashOnDelivery,

        [Display(Name = "Bill To Account")]
        BillToAccount
    }
}
