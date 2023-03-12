using System.Security.AccessControl;

namespace Library.Service.DTOs.Admin.Book;

public class BookIndexDTO
{

    public List<BookDTO> books { get; set; } = new();
}