using System;

namespace Projekt.Repository.Filters
{
    public class VehicleMakeFilter
    {
        public string SearchString { get; set; }
        public string SortOrder { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }

        public int DefaultPageSize = 15;

        private void SetPageNumberAndSize(int pageNumber = 1, int pageSize = 0)
        {
            PageNumber = (pageNumber > 0) ? pageNumber : 1;
            PageSize = (pageSize > 0 && pageSize <= DefaultPageSize) ? pageSize : DefaultPageSize;
        }

        public VehicleMakeFilter(string searchString, int pageNumber, int pageSize)
        {
                SearchString = searchString;
                SetPageNumberAndSize(pageNumber, pageSize);
        }
    }
}