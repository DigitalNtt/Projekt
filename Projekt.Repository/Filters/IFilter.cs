using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
