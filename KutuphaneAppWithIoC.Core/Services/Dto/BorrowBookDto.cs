namespace KutuphaneAppWithIoC.Core.Services.Dto
{
    public class BorrowBookDto
    {
        public string Borrower { get; set; }
        public int Isbn { get; set; }
        public int BookId { get; set; }
    }
}