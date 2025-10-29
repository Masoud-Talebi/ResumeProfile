namespace ResumeProfile.Application.Common.GenericFilters
{
    public class SearchQueryRequest : GridifyQuery
    {       
        public SearchQueryRequest(int page = 1, int pageSize = 20, string orderBy = "", string filter = "")
        {
            PageSize = pageSize;
            OrderBy = orderBy;
            Filter = filter;
            Page = page;
        }
    }
}
