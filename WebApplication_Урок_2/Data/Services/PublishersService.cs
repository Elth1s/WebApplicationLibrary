using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Урок_2.Data.Models;
using WebApplication_Урок_2.Data.ViewModels;

namespace WebApplication_Урок_2.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Publisher> GetPublishers(string sortBy, string searchString, int pageNumber)
        {
            IEnumerable<Publisher> publishers = _context.Publishers.OrderBy(p => p.Name);
            if (!String.IsNullOrEmpty(searchString))
            {
                publishers = publishers.Where(p => p.Name.Contains(searchString)).ToList();
            }

            if (!string.IsNullOrEmpty(sortBy) && sortBy.ToLower() == "desc")
            {
                publishers = publishers.OrderByDescending(p => p.Name).ToList();
            }

            
            if (pageNumber > 0)
            {
                publishers = publishers.Skip((pageNumber - 1) * 6).Take(6).ToList();
            }
            else if(pageNumber == 0)
            {
                publishers = publishers.Take(6).ToList();
            }
            else
            {
                throw new Exception($"Page number less than 0");
            }

             


            return publishers;
        }
        public Publisher GetPublisherById(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
            if (publisher != null)
                return publisher;
            else
                return null;
        }
        public PublisherWithBooksAndAuthotsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthotsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Title,
                        BookAuthors = n.Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }
        public Publisher AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }
        public void DeletePublisher(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(b => b.Id == id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with id: {id} not found");
            }
        }
        public Publisher UpdatePublisherById(int publisherId, PublisherVM publisher)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);

            if (_publisher != null)
            {
                _publisher.Name = publisher.Name;

                _context.SaveChanges();
            }

            return _publisher;
        }
    }
}
