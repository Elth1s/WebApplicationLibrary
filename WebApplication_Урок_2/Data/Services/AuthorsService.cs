using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Урок_2.Data.Models;
using WebApplication_Урок_2.Data.ViewModels;

namespace WebApplication_Урок_2.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAuthors()
        {
            var authors = _context.Authors;
            return authors;
        }
        public Author GetAuthorById(int id)
        {
            var author = _context.Authors.FirstOrDefault(p => p.Id == id);
            if (author != null)
                return author;
            else
                return null;
        }
        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Books.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }
        public Author AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();

            return _author;
        }
        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.FirstOrDefault(b => b.Id == id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Author with id: {id} not found");
            }
        }
        public Author UpdateAuthorById(int authorId, AuthorVM author)
        {
            var _author = _context.Authors.FirstOrDefault(n => n.Id == authorId);

            if (_author != null)
            {
                _author.FullName = author.FullName;

                _context.SaveChanges();
            }

            return _author;
        }
    }
}
