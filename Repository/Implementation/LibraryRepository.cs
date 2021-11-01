using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFBackEnd.Entities;
using EFBackEnd.Repository.Contract;

namespace EFBackEnd.Repository.Implementation
{
    public class LibraryRepository:ILibraryRepository<Author>
    {
        readonly LibraryContext _libraryContext;

        public LibraryRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return _libraryContext.Authors.ToList();
        }

        public Author Get(Guid authorId)
        {
            try
            {
                return _libraryContext.Authors.Find(authorId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Author Post(Author author)
        {
            try
            {
                if (_libraryContext != null)
                {
                    _libraryContext.Authors.Add(author);
                    _libraryContext.SaveChanges();
                    return author;
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

        public Author Update(Author author)
        {
            try
            {
                if (_libraryContext != null)
                {
                    _libraryContext.Authors.Update(author);
                    _libraryContext.SaveChanges();
                    return author;
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

        public int Delete(Guid authorId)
        {
            try
            {
                if (_libraryContext != null)
                {
                    var author = _libraryContext.Authors.Find(authorId);
                    if (author != null)
                    {
                        _libraryContext.Authors.Remove(author);
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
