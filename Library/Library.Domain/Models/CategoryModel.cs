using Library.Common.BaseModel;

namespace Library.Domain.Models;

public class CategoryModel : BaseModel
{
    public string CategoryName { get; set; }

    public List<BookModel> Books { get; set; }
}   