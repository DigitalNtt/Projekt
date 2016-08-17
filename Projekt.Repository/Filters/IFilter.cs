namespace Projekt.Repository.Filters
{
    public interface IFilter
    {
        string SearchString { get; }
        string SortOrder { get; }
        int PageNumber { get; }
        int PageSize { get; }
    }
}