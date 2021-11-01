using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFBackEnd.Entities;
using EFBackEnd.Repository.Contract;

namespace EFBackEnd.Repository.Implementation
{
    public class MemberRepository:ILibraryRepository<Member>
    {
        readonly LibraryContext _libraryContext;

        public MemberRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public IEnumerable<Member> GetAll()
        {
            return _libraryContext.Members.ToList();
        }

        public Member Get(Guid memberId)
        {
            try
            {
                return _libraryContext.Members.Find(memberId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Member Post(Member member)
        {
            try
            {
                if (_libraryContext != null)
                {
                    _libraryContext.Members.Add(member);
                    _libraryContext.SaveChanges();
                    return member;
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

        public Member Update(Member member)
        {
            try
            {
                if (_libraryContext != null)
                {
                    _libraryContext.Members.Update(member);
                    _libraryContext.SaveChanges();
                    return member;
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

        public int Delete(Guid memberId)
        {
            try
            {
                if (_libraryContext != null)
                {
                    var member = _libraryContext.Members.Find(memberId);
                    if (member != null)
                    {
                        _libraryContext.Members.Remove(member);
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
