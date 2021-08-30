using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Урок_2.Data.Models;
using WebApplication_Урок_2.Data.ViewModels;

namespace WebApplication_Урок_2.Data.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            var books = _context.Books;
            return books;
        }
        public BooksWithAuthorsVM GetBookById(int id)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.Id == id).Select(book => new BooksWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                ImageURL = book.Image,
                PublisherName = book.Publisher.Name,
                AuthorsNames = book.Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
        }
        public void AddBookWithAuthors(BookVM book)
        {
            Book _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                DateAdded = book.DateAdded,
                DateRead = book.DateRead,
                Genre = book.Genre,
                Image = book.Image,
                IsRead = book.IsRead,
                Rate = book.Rate,
                PublisherId=book.PublisherId,
                
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            if (book.AuthorsId != null)
                foreach (var id in book.AuthorsId)
                {
                    var authorBook = new AuthorBook()
                    {
                        BookId = _book.Id,
                        AuthorId = id
                    };
                    _context.AuthorsBooks.Add(authorBook);
                    _context.SaveChanges();
                }
        }
        public void DeleteBook(int id)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == id);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Book with id: {id} not found");
            }
        }
        public Book UpdateBookById(int id, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == id);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _book.Image = book.Image;

                _context.SaveChanges();
            }

            return _book;
        }

    }
}
