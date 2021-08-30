using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Урок_2.Data.Models;

namespace WebApplication_Урок_2.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }
    public class PublisherWithBooksAndAuthotsVM
    {
        public string Name { get; set; }
        public List<BookAuthorVM> BookAuthors { get; set; }
    }

    public class BookAuthorVM
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }

    public class PublisherWithInfo
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IEnumerable<Publisher> Publishers { get; set; }
    }
}
