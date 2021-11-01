using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFBackEnd.Entities;
using EFBackEnd.Repository.Contract;
using EFBackEnd.Repository.Implementation;
using Microsoft.AspNetCore.Cors;

namespace EFBackEnd.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibraryRepository<Author> _libraryRepository;
        private readonly ILibraryRepository<Book> _bookRepository;
        private readonly ILibraryRepository<Lend> _lendRepository;
        private readonly ILibraryRepository<Member> _memberRepository;

        public LibrariesController(ILibraryRepository<Author> libraryRepository, ILibraryRepository<Book> bookRepository, ILibraryRepository<Lend> lendRepository, ILibraryRepository<Member> memberRepository)
        {
            _libraryRepository = libraryRepository;
            _bookRepository = bookRepository;
            _lendRepository = lendRepository;
            _memberRepository = memberRepository;
        }

        [HttpGet]
        [Route("authors")]
        public IActionResult GetAllAuthors()
        {
            IEnumerable<Author> authors = _libraryRepository.GetAll();
            return Ok(authors);
        }

        [Route("author/{authorId}")]
        [HttpGet("/{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            try
            {
                Author author = _libraryRepository.Get(authorId);
                return Ok(author);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("author")]
        public IActionResult AddAuthor([FromBody] Author authorParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Author author = _libraryRepository.Post(authorParam);
                    return Ok(author);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [Route("author/update/{authorId}")]
        [HttpPatch("/{authorId}")]
        public IActionResult UpdateAuthor([FromBody] Author authorParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Author author = _libraryRepository.Update(authorParam);
                    return Ok(author);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [Route("author/delete/{authorId}")]
        [HttpDelete("/{authorId}")]
        public IActionResult DeleteAuthor(Guid authorId)
        {
            try
            {
                int result = _libraryRepository.Delete(authorId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("books")]
        public IActionResult GetAllBooks()
        {
            IEnumerable<Book> books = _bookRepository.GetAll();
            return Ok(books);
        }

        [Route("book/{bookId}")]
        [HttpGet("/{bookId}")]
        public IActionResult GetBook(Guid bookId)
        {
            try
            {
                Book book = _bookRepository.Get(bookId);
                return Ok(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("book")]
        public IActionResult AddBook([FromBody] Book bookParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Book book = _bookRepository.Post(bookParam);
                    return Ok(book);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [Route("book/update/{bookId}")]
        [HttpPatch("/{bookId}")]
        public IActionResult UpdateBook([FromBody] Book bookParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Book book = _bookRepository.Update(bookParam);
                    return Ok(book);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [Route("book/delete/{bookId}")]
        [HttpDelete("/{bookId}")]
        public IActionResult DeleteBook(Guid bookId)
        {
            try
            {
                int result = _bookRepository.Delete(bookId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("lends")]
        public IActionResult GetAllLends()
        {
            IEnumerable<Lend> lends = _lendRepository.GetAll();
            return Ok(lends);
        }

        [Route("lend/{lendId}")]
        [HttpGet("/{lendId}")]
        public IActionResult GetLend(Guid lendId)
        {
            try
            {
                Lend lend = _lendRepository.Get(lendId);
                return Ok(lend);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("lend")]
        public IActionResult AddLend([FromBody] Lend lendParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    lendParam.Book = _bookRepository.Get(lendParam.BookId);
                    lendParam.Member = _memberRepository.Get(lendParam.MemberId);
                    Lend lend = _lendRepository.Post(lendParam);
                    return Ok(lend);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [Route("lend/update/{lendId}")]
        [HttpPatch("/{lendId}")]
        public IActionResult UpdateLend([FromBody] Lend lendParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Lend lend= _lendRepository.Update(lendParam);
                    return Ok(lend);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [Route("lend/delete/{lendId}")]
        [HttpDelete("/{lendId}")]
        public IActionResult DeleteLend(Guid lendId)
        {
            try
            {
                int result = _lendRepository.Delete(lendId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("members")]
        public IActionResult GetAllMembers()
        {
            IEnumerable<Member> members = _memberRepository.GetAll();
            return Ok(members);
        }

        [Route("lend/{memberId}")]
        [HttpGet("/{memberId}")]
        public IActionResult GetMember(Guid memberId)
        {
            try
            {
                Member member= _memberRepository.Get(memberId);
                return Ok(member);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("member")]
        public IActionResult AddMember([FromBody] Member memberParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Member member= _memberRepository.Post(memberParam);
                    return Ok(member);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [Route("member/update/{memberId}")]
        [HttpPatch("/{memberId}")]
        public IActionResult UpdateMember([FromBody] Member memberParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Member member= _memberRepository.Update(memberParam);
                    return Ok(member);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [Route("member/delete/{memberId}")]
        [HttpDelete("/{memberId}")]
        public IActionResult DeleteMember(Guid memberId)
        {
            try
            {
                int result = _memberRepository.Delete(memberId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}
