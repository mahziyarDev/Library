using System.ComponentModel.DataAnnotations;

namespace Library.Common.Enum;

public enum bookStatus
{
    [Display(Name = "قرض گرفته شده")]
    Borrowed,

    [Display(Name = "تحویل داده شده")]
    Delivered
}