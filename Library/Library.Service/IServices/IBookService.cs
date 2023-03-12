using Library.Common.OperationResult;
using Library.Service.DTOs.Admin.Book;
using Library.Service.DTOs.Admin.Borrowed;

namespace Library.Service.IServices;

public interface IBookService:IAsyncDisposable
{
    Task<OperationResult<BookIndexDTO>> GetBooks();
    Task<OperationResult<BookDTO>> GetBook(Guid id);
    Task<OperationResult> ManageBook(BookManageDTO manage);
    Task<OperationResult> BorrowedBook(BookBorrowedDTO bookBorrowed);
}