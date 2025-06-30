using System.ComponentModel.DataAnnotations;

namespace Library.DataBase.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Author { get; set; }
        public int CopiesAvailable { get; set; }
        public bool Status { get; set; }
        public ICollection<BorrowModel>? Borrows { get; set; } 
    }
}
