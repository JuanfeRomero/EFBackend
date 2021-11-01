using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFBackEnd.Entities;
using EFBackEnd.Repository.Contract;

namespace EFBackEnd.Repository.Implementation
{
    public class BookRepository: ILibraryRepository<Book>
    {
        readonly LibraryContext _libraryContext;

        public BookRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _libraryContext.Books.ToList();
        }

        public Book Get(Guid bookId)
        {
            try
            {
                return _libraryContext.Books.Find(bookId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Book Post(Book book)
        {
            try
            {
                if (_libraryContext != null)
                {
                    _libraryContext.Books.Add(book);
                    _libraryContext.SaveChanges();
                    return book;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Book Update(Book book)
        {
            try
            {
                if (_libraryContext != null)
                {
                    _libraryContext.Books.Update(book);
                    _libraryContext.SaveChanges();
                    return book;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public int Delete(Guid bookId)
        {
            try
            {
                if (_libraryContext != null)
                {
                    var book = _libraryContext.Books.Find(bookId);
                    if (book != null)
                    {
                        _libraryContext.Books.Remove(book);
                        _libraryContext.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }
    }
}
