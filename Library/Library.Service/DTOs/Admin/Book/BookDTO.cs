using Library.Common.Enum;

namespace Library.Service.DTOs.Admin.Book;

public class BookDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string CategoryName { get; set; }
}