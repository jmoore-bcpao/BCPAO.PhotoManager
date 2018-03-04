using System.ComponentModel.DataAnnotations;
 
namespace BCPAO.PhotoManager.Models.Enums
{
    public enum FieldType
    {
        [Display(Name = "Number")]
        Number,

        [Display(Name = "Text")]
        Text
    }
}
