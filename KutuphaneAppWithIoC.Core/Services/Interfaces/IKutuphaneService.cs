using System.Collections.Generic;
using KutuphaneAppWithIoC.Core.Services.Dto;

namespace KutuphaneAppWithIoC.Core.Services.Interfaces
{
    public interface IKutuphaneService : IService
    {
        void InsertNewBook(InsertBookDto dto);
        IEnumerable<BookDto> GetAllBooks();
        IEnumerable<LogDto> GetAllLogs();
        BookDto GetBookDetail(int isbn);
        void UpdateBook(InsertBookDto dto);
        void DeleteBook(int isbn);
        void BorrowBook(BorrowBookDto dto);
    }
}
