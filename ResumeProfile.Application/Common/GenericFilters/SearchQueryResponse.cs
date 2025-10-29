namespace ResumeProfile.Application.Common.GenericFilters
{
    public class SearchQueryResponse<T> where T : class
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int TotalCount { get; set; } = 0;
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / (PageSize <= 0 ? 1 : PageSize));

        public SearchQueryResponse() { }

        public SearchQueryResponse(SearchQueryRequest request, Paging<T> result)
        {
            Items = result.Data;
            TotalCount = result.Count;
            PageNumber = request.Page;
            PageSize = request.PageSize;
        }

    }
}
