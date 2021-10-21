using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Challenge.Kernel.Application.DataTransferObjects
{
    public class PagedResultDTO<T>
        where T : BaseDTO
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalResults { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
