using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.DataBase.Models
{
    public class BorrowModel
    {
        public int? PersonId { get; set; }
        public PersonModel? Person { get; set; }
        public int? BookId { get; set; }
        public BookModel? Book { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime? ReternDate { get; set; }
    }
}



