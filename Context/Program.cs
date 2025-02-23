using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Init();

        }
        static void AddPublisher(Publisher publisher)
        {
            using (LibriaryEntity db = new LibriaryEntity())
            {
                Publisher a = db.Publisher.Where((x) =>
                x.PublisherName == publisher.
                PublisherName).FirstOrDefault();
                if (a == null)
                {
                    db.Publisher.Add(publisher);
                    db.SaveChanges();
                    Console.WriteLine("New publisher added: " + publisher.PublisherName);
                }
            }
        }
        static void AddBook(Book book)
        {
            using (LibriaryEntity db = new LibriaryEntity())
            {
                Book a = db.Book.Where((x) => x.Title == book.Title).FirstOrDefault();
                if (a == null)
                {
                    db.Book.Add(book);
                    var tmp = db.Book.ToList();
                    db.SaveChanges();
                    Console.WriteLine("New book added:" +
                    book.Title);
                }
            }
        }
        static void AddAuthor(Author author)
        {
            using (LibriaryEntity db = new LibriaryEntity())
            {
                var tmp = db.Author.Where(p => p.FirstName == author.FirstName && p.LastName == author.LastName).FirstOrDefault();
                if (tmp == null)
                {
                    db.Author.Add(author);
                    db.SaveChanges();
                    Console.WriteLine($"{author.FirstName} {author.LastName} добавлен");
                }
                else
                    Console.WriteLine($"{author.FirstName} {author.LastName} не добавлен");
            }
        }
        static void Init()
        {
            Author author = new Author
            {
                FirstName = "Ray",
                LastName = "Bradbury"
            };
            AddAuthor(author);
            author = new Author
            {
                FirstName = "Harry",
                LastName = "Harrison"
            };
            AddAuthor(author);
            author = new Author
            {
                FirstName = "FictionFirstName",
                LastName = "FictionLastName"
            };
            AddAuthor(author);
            author = new Author
            {
                FirstName = "Clifford",
                LastName = "Simak"
            };
            AddAuthor(author);

            Publisher publisher = new Publisher
            {
                PublisherName = "Rainbow",
                Address = "Tula"
            };
            AddPublisher(publisher);
            publisher = new Publisher
            {
                PublisherName =  "Exlibris",
                Address = "Tula"
            };
            AddPublisher(publisher);
            publisher = new Publisher
            {
                PublisherName = "FictionPublisher",
                Address = "Tula"
            };
            AddPublisher(publisher);
            Book book = new Book
            {
                Title = "Way Station",
                IdPublisher = 1,
                IdAuthor = 4,
                Pages = 350,
                Price = 85
            };
            AddBook(book);
            book = new Book
            {
                Title = "Ring Around the  Sun", IdPublisher = 1, IdAuthor = 4, 
            Pages = 420,
                Price = 99
            };
            AddBook(book);
            book = new Book
            {
                Title = "The Martian Chronicles", IdPublisher = 2, IdAuthor = 2,
            Pages = 410,
                Price = 105
            };

            AddBook(book);
            book = new Book
            {
                Title = "I, Robot",
                IdPublisher = 3,
                IdAuthor = 1,
                Pages = 378,
                Price = 100
            };
            AddBook(book);
        }

        static void GetAllAuthors()
        {
            using (LibriaryEntity db = new LibriaryEntity())
            {
                List<Author> authors =  db.Author.ToList();
                foreach(Author author in authors)
                {
                    Console.WriteLine($"{author.FirstName} {author.LastName}!");
                }    
            }
        }
        static Author GetAuthorByName(string first_name)
        {
            Author myAuthor;
            using (LibriaryEntity db = new LibriaryEntity())
            {
                myAuthor = db.Author.Where(p=>p.FirstName == first_name).OrderByDescending(p=>p.Id).FirstOrDefault();
            }
                return myAuthor;
        }
        static List<Author> GetAuthorsByName(string first_name)
        {
    
            using (LibriaryEntity db = new LibriaryEntity())
            {
                return db.Author.Where(p => p.FirstName == first_name).ToList();
            }
          
        }
        static Author GetAuthorById(int id)
        {
            Author myAuthor = new Author();
            using (LibriaryEntity db = new LibriaryEntity())
            {
                var authors = db.Author.Find(id);
            }
            return myAuthor;
        }
    }
}
