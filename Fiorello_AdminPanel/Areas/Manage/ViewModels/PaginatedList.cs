namespace Fiorello_AdminPanel.Areas.Manage.ViewModels
{
    public class PaginatedList<T>
    {
        public PaginatedList(List<T> items, int pageIndex, int totalPages)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = totalPages;
        }
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious => PageIndex > 1;
        public bool HasNext => PageIndex < TotalPages;
        public static PaginatedList<T> Create(IQueryable<T> query, int pageindex, int pagesize)
        {
            var items = query.Skip((pageindex-1)*pagesize).Take(pagesize).ToList();
            var totalpages = (int)Math.Ceiling(query.Count() / (double)pagesize);
            return new PaginatedList<T>(items,pageindex,totalpages);
        }
    }
}
