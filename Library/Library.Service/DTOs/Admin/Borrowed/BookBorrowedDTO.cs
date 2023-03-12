namespace Library.Service.DTOs.Admin.Borrowed;

public class BookBorrowedDTO
{
    /// <summary>کسی که کتاب  را قرض گرفته است</summary>
    public Guid UserId { get; set; }

    /// <summary>کتابی که قرض گرفته شده است</summary>
    public Guid BookId { get; set; }

    /// <summary>تاریخ شروع گرفتن کتاب</summary>
    public DateTime? Start { get; set; }

    /// <summary>تاریخ تحویل کتاب</summary>
    public DateTime? Finish { get; set; }
    
}