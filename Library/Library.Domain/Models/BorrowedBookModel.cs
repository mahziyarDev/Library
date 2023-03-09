using Library.Common.BaseModel;
namespace Library.Domain.Models;

public class BorrowedBookModel : BaseModel
{
    public UserModel User { get; set; }
    public Guid UserId { get; set; }

    public BookModel Book { get; set; }
    public Guid BookId { get; set; }

    public TimeSpan? LoanEndDate { get; set; }

}