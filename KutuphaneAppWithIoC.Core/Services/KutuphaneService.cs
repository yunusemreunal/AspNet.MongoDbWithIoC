using System.Collections.Generic;
using System.Linq;
using KutuphaneAppWithIoC.Core.Models;
using KutuphaneAppWithIoC.Core.Services.Const;
using KutuphaneAppWithIoC.Core.Services.Dto;
using KutuphaneAppWithIoC.Core.Services.Interfaces;
using KutuphaneAppWithIoC.Core.Structure;
using MongoDB.Driver.Linq;

namespace KutuphaneAppWithIoC.Core.Services
{
    public class KutuphaneService : ServiceBase, IKutuphaneService
    {
        public void InsertNewBook(InsertBookDto dto)
        {
            var newBook = new Book
            {
                Author = dto.Author,
                Title = dto.Title,
                Isbn = dto.Isbn,
                Status = GeneralConsts.KitapDurumuKutuphanede
            };

            UnitOfWork.CurrentSession.Books.Save(newBook);
            SetResultAsSuccess(ServiceResultCode.Success, "Yeni Kitap Eklendi");
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            var books = UnitOfWork.CurrentSession.Books.AsQueryable()
                .Select(p => new BookDto
                {
                    Isbn = p.Isbn,
                    Author = p.Author,
                    Status = p.Status,
                    Title = p.Title
                })
                .ToList();

            return books;
        }

        public IEnumerable<LogDto> GetAllLogs()
        {
            var processLogs = UnitOfWork.CurrentSession.ProcessLogs.AsQueryable()
              .Select(p => new LogDto
              {
                  Borrower = p.Borrower,
                  Isbn = p.Isbn
              })
              .ToList();

            foreach (var processLog in processLogs)
            {
                var book = UnitOfWork.CurrentSession
                    .Books.AsQueryable()
                    .FirstOrDefault(p => p.Isbn == processLog.Isbn);

                if (book != null)
                {
                    processLog.BookTitle = book.Title;
                }
            }

            return processLogs;
        }

        public BookDto GetBookDetail(int isbn)
        {
            var pageDto = new BookDto();

            var book = UnitOfWork.CurrentSession.Books.AsQueryable()
                 .FirstOrDefault(p => p.Isbn == isbn);

            if (book != null)
            {
                pageDto.Author = book.Author;
                pageDto.Isbn = book.Isbn;
                pageDto.Title = book.Title;
            }

            return pageDto;
        }

        public void UpdateBook(InsertBookDto dto)
        {
            var book = UnitOfWork.CurrentSession.Books.AsQueryable()
                 .FirstOrDefault(p => p.Isbn == dto.Isbn);

            if (book != null)
            {
                book.Author = dto.Author;
                book.Title = dto.Title;
                UnitOfWork.CurrentSession.Books.Save(book);
                SetResultAsSuccess(ServiceResultCode.Success, "Kitap Güncellendi");
                return;
            }
            SetResultAsFail(ServiceResultCode.Fail, "Kitap Güncellenemedi");


        }

        public void DeleteBook(int isbn)
        {

            var book = from p in UnitOfWork.CurrentSession.Books.AsQueryable<Book>() where p.Isbn == isbn select p;
            var mongoQuery = ((MongoQueryable<Book>)book).GetMongoQuery();

            UnitOfWork.CurrentSession.Books.Remove(mongoQuery);


            var bookOfLog = from p in UnitOfWork.CurrentSession.ProcessLogs.AsQueryable<ProcessLog>() where p.Isbn == isbn select p;
            var mongoQueryToRemoveBookOfLog = ((MongoQueryable<ProcessLog>)bookOfLog).GetMongoQuery();

            UnitOfWork.CurrentSession.ProcessLogs.Remove(mongoQueryToRemoveBookOfLog);
            SetResultAsSuccess(ServiceResultCode.Success, "Kitap Silindi");

        }

        public void BorrowBook(BorrowBookDto dto)
        {
            var book = UnitOfWork.CurrentSession.Books.AsQueryable()
                 .FirstOrDefault(p => p.Isbn == dto.Isbn
                 && p.Status == GeneralConsts.KitapDurumuKutuphanede);

            if (book != null)
            {
                book.Status = GeneralConsts.KitapDurumuOduncVerildi;
                UnitOfWork.CurrentSession.Books.Save(book);

                var newLog = new ProcessLog
                {
                    Borrower = dto.Borrower,
                    Isbn = dto.Isbn
                };

                UnitOfWork.CurrentSession.ProcessLogs.Save(newLog);

                SetResultAsSuccess(ServiceResultCode.Success, "Kitap Ödünç Verildi");
                return;
            }
            SetResultAsFail(ServiceResultCode.Fail, "Kitap Ödünç Verilemedi");
        }
    }
}
