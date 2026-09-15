namespace TraineeAPI.ViewModel
{
    /// <summary>
    /// Generic wrapper for outgoing responses.
    /// T = the actual payload (e.g. Student, IEnumerable&lt;Course&gt;, etc.)
    /// </summary>
    public class ResponseViewModel<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        // Optional paging metadata - populate only when Data is a list
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public int? TotalRecords { get; set; }
        public int? TotalPages =>
            (TotalRecords.HasValue && PageSize is > 0)
                ? (int)Math.Ceiling(TotalRecords.Value / (double)PageSize)
                : null;

        public static ResponseViewModel<T> SuccessResponse(T data, string? message = null)
        {
            return new ResponseViewModel<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static ResponseViewModel<T> SuccessPagedResponse(
            T data, int pageNumber, int pageSize, int totalRecords, string? message = null)
        {
            return new ResponseViewModel<T>
            {
                Success = true,
                Data = data,
                Message = message,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };
        }

        public static ResponseViewModel<T> FailResponse(List<string> errors, string? message = null)
        {
            return new ResponseViewModel<T>
            {
                Success = false,
                Errors = errors,
                Message = message
            };
        }

        public static ResponseViewModel<T> FailResponse(string error, string? message = null)
        {
            return FailResponse(new List<string> { error }, message);
        }
    }
}