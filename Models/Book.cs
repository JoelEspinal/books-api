namespace BookApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string? Title { get; set; }

        public int PageCount { get; set; }

        public string? Excerpt { get; set; }

        public DateTime publishDate { get; set; }
    }
}
