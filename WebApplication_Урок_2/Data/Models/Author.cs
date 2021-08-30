using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Урок_2.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<AuthorBook> Books { get; set; }
    }
}
