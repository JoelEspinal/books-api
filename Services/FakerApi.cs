
using BookApi.DTO;
using System.Text.Json;
using System.Text;


namespace BookApi.Services
{
    public class FakerApi
    {
        static HttpClient client = new HttpClient();

        const string BOOK_URL = "https://fakerestapi.azurewebsites.net/api/v1/Books";

        public static async Task<IEnumerable<BookDTO>> GetBooksAsync()
        {
            IEnumerable<BookDTO> books = null;

            var response = await client.GetAsync(BOOK_URL);

            if (response.IsSuccessStatusCode)
            {
                books = await response.Content.ReadAsAsync<IEnumerable<BookDTO>>();
            }

            return books;
        }

        public static async Task<BookDTO> GetBooksAsync(long id)
        {
            var getBook = BOOK_URL + "/" + id;
            HttpResponseMessage response = await client.GetAsync(getBook);

            BookDTO book = null;
            if (response.IsSuccessStatusCode)
            {
                book = await response.Content.ReadAsAsync<BookDTO>();
            }

            return book;

        }

        public static async Task<HttpResponseMessage> CreateBook(BookDTO book)
        {

            string json = JsonSerializer.Serialize(book);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PostAsync(BOOK_URL, content);

        }

        public static async Task<HttpResponseMessage> EditBook(long id, BookDTO book)
        {
            string json = JsonSerializer.Serialize(book);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PutAsync(BOOK_URL, content);

        }

        public static async Task<HttpResponseMessage> DeleteBook(long id)
        {
            var deleteBook = BOOK_URL + "/" + id;
            return await client.DeleteAsync(BOOK_URL);

        }
    }
 }