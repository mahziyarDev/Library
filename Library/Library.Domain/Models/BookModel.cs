using System.ComponentModel.DataAnnotations;
using Library.Common.BaseModel;
using Library.Common.Enum;

namespace Library.Domain.Models;

public class BookModel : BaseModel
{
    [Required]
    [MaxLength(250)]
    public string BookName { get; set; }

    [Required]
    public bookStatus Status { get; set; }

}