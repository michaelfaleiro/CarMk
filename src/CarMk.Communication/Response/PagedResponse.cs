namespace CarMk.Communication.Response;

public class PagedResponse<TData>
{
    public int PageNumber { get; set; } 
    public int PageSize { get; set; } 
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public long TotalCount { get; set; }
    public IEnumerable<TData> Data { get; set; } = default!; 
    
}