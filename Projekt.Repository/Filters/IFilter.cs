namespace Projekt.Repository.Filters
{
    public interface IFilter
    {
        string SearchString { get; }
    }
    public interface ISort
    {
        string SortOrder { get; }
    }
    public interface IPaging
    {
        int PageNumber { get; }
        int PageSize { get; }
    }
}