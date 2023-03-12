using Library.Service.DTOs.Admin.Category;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Service.DTOs.Admin.Book;

public class BookManageDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public List<CategoryDTO> Categories { get; set; } = new();
    public Guid CategoryId { get; set; }
}