using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Урок_2.Data.Models
{
    public class AuthorBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }

}
