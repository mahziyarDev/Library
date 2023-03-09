using Library.Common.BaseModel;

namespace Library.Domain.Models;

public class BookCategoryModel : BaseModel
{

    public BookModel Book { get; set; }
    public Guid BookId { get; set; }

    public CategoryModel Category { get; set; }
    public Guid CategoryId { get; set; }
}