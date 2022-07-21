namespace BookApi.DTO
{
    public class BookDTO
    {
        public long Id { get; set; }
        public string? Title { get; set; }

        public int PageCount { get; set; }
        
        public string? Excerpt { get; set; }
        
        public DateTime publishDate { get; set; }
    }
}