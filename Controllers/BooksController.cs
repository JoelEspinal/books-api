using Microsoft.AspNetCore.Mvc;
using BookApi.DTO;
using BookApi.Services;
using System.Net;

namespace BookApi.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<BookDTO>> GetBooks()
        {
            var response = await FakerApi.GetBooksAsync();
            return response;

        }

        // GET: api/Books/{id}
        [HttpGet("{id}")]
        public async Task<BookDTO> GetBook(long id)
        {
            var response = await FakerApi.GetBooksAsync(id);
            return response;
        }


        // POST: api/Books/{id}
        [HttpPost]
        public async Task<HttpResponseMessage> CreateBook(BookDTO book)
        {
      
            return await FakerApi.CreateBook(book);
            
        }


        // PUT: api/Books/{id}
        [HttpPut("{id}")]
        public async Task<HttpResponseMessage> EditBook(long id, BookDTO book)
        {
            if(id != book.Id)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return await FakerApi.EditBook(id, book);
        }


        // DELETE: api/Books/{id}
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteBook(long id)
        {
            return await FakerApi.DeleteBook(id);
        }
    }   
}