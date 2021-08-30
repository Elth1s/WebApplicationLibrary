using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Урок_2.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }
        public DateTime DateAdded { get; set; }

        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<AuthorBook> Authors { get; set; }
    }
}
