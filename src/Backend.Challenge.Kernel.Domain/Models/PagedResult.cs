using System.Collections.Generic;

namespace Backend.Challenge.Kernel.Domain
{
    public class PagedResult<T>
    {
        public IEnumerable<T> List { get; set; }
        public int TotalResults { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
