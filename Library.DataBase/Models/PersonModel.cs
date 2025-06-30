using System.ComponentModel.DataAnnotations;

namespace Library.DataBase.Models
{
    public class PersonModel
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }
        public string? Address { get; set; }
        public ICollection<BorrowModel>? Borrows { get; set; } 



    }
}
