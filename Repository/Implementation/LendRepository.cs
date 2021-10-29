using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFBackEnd.Entities;
using EFBackEnd.Repository.Contract;

namespace EFBackEnd.Repository.Implementation
{
    public class LendRepository:ILibraryRepository<Lend>
    {
        readonly LibraryContext _libraryContext;

        public LendRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public IEnumerable<Lend> GetAll()
        {
            return _libraryContext.Lends.ToList();
        }

        public Lend Get(Guid lendId)
        {
            try
            {
                return _libraryContext.Lends.Find(lendId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Lend Post(Lend lend)
        {
            try
            {
                if (_libraryContext != null)
                {
                    _libraryContext.Lends.Add(lend);
                    _libraryContext.SaveChanges();
                    return lend;
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

        public Lend Update(Lend lend)
        {
            try
            {
                if (_libraryContext != null)
                {
                    _libraryContext.Lends.Update(lend);
                    _libraryContext.SaveChanges();
                    return lend;
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

        public int Delete(Guid lendId)
        {
            try
            {
                if (_libraryContext != null)
                {
                    var lend = _libraryContext.Lends.Find(lendId);
                    if (lend != null)
                    {
                        _libraryContext.Lends.Remove(lend);
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
