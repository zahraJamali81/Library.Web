using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel.ViewModels
{
    public class BookVm
    {
        public int BookId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        public int CopiesAvailable { get; set; }
        public bool Status { get; set; }
    }
}
