namespace Products.Helpers
{
    public class PaginationResult<T>
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int Size { get; set; }
        public int TotalRecords { get; set; }
        public List<T> values { get; set; } = new List<T>();
    }
}
