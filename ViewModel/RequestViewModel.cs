namespace TraineeAPI.ViewModel
{
    /// <summary>
    /// Generic wrapper for incoming requests.
    /// T = the actual payload (e.g. Student, Course, etc.)
    /// </summary>
    public class RequestViewModel<T>
    {
        public T? Data { get; set; }

        // Optional paging/sorting/filtering metadata - used only on "list" endpoints
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; }
        public bool Descending { get; set; } = false;
        public string? SearchTerm { get; set; }
    }
}