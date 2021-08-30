using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Урок_2.Data.ViewModels
{
    public class BookVM
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
        public IEnumerable<int> AuthorsId { get; set; }
    }
    public class BooksWithAuthorsVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string ImageURL { get; set; }
        public DateTime DateAdded { get; set; }

        public string PublisherName { get; set; }
        public List<string> AuthorsNames { get; set; }
    }
}
