using System.Security.AccessControl;
using Library.Common.Extention;
using Library.Common.OperationResult;
using Library.Domain.Context;
using Library.Service.DTOs.Admin.Book;
using Library.Service.DTOs.Admin.Borrowed;
using Library.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace Library.Service.Services;

public class BookService : IBookService
{
    private readonly LibraryDataContext _db;

    public BookService(LibraryDataContext db)
    {
        _db = db;
    }

    public async ValueTask DisposeAsync()
    {
        await _db.DisposeAsync();
    }

    public async Task<OperationResult<BookIndexDTO>> GetBooks()
    {
        var books = await _db.Books
            .Include(m => m.Category)
            .ToListAsync();
        return new OperationResult<BookIndexDTO>
        (
            "0",
            true,
            OperationResultMessage.Success,
            new BookIndexDTO
            {
                books = books.Select(m =>
                    new BookDTO
                    {
                        CategoryName = m.Category.CategoryName,
                        Name = m.BookName,
                        Id = m.Id,
                        Status = m.Status.GetName()
                    }
                ).ToList()
            }
        );
    }

    public async Task<OperationResult<BookDTO>> GetBook(Guid id)
    {
        var book = await _db.Books
            .Include(m=>m.Category)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (book == null)
            return new OperationResult<BookDTO>("0", false, OperationResultMessage.NotFound);
        return new OperationResult<BookDTO>
        (
            "0",
            true,
            OperationResultMessage.Success,
            new BookDTO
            {
                CategoryName = book.Category.CategoryName,
                Name = book.BookName,
                Status = book.Status.GetName(),
                Id = book.Id
            }
        );
    }

    public async Task<OperationResult> ManageBook(BookManageDTO manage)
    {
        // if (manage.Id.HasValue)
        // {
        //  var book = await _db.Books.
        // }
        throw new NotImplementedException();
    }

    public Task<OperationResult> BorrowedBook(BookBorrowedDTO bookBorrowed)
    {
        throw new NotImplementedException();
    }
}