using Library.Common.BaseModel;
using Library.Domain.Models.Identity;

namespace Library.Domain.Models;

public class BorrowedBookModel : BaseModel
{
    public ApplicationUser User { get; set; }
    public Guid UserId { get; set; }

    public BookModel Book { get; set; }
    public Guid BookId { get; set; }

    public DateTime StartBorrower { get; set; }
    public DateTime FinishBorrower { get; set; }

}